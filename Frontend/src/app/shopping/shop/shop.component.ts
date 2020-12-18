import {Component, OnDestroy, OnInit} from '@angular/core';

import itemsJson from '../../../../../Assets/items.json';
import { Subscription } from 'rxjs';
import { Items } from 'src/model/item';
import { UserItemService } from 'src/app/services/user-item-service';
import { UserApiService } from 'src/app/services/user-api.service';
import { User } from 'src/app/model/user';
import { UserItem } from 'src/app/model/user-item';
import {GlobalUser} from '../../helpers/global-user';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.less']
})
export class ShopComponent implements OnInit, OnDestroy {

  items: Items = itemsJson;
  userItem: UserItem = null;
  user: User;
  id = 1;

  private subscription: Subscription[] = [];

  quantity = 1;
  isHidden = true;

  constructor(private userItemApi: UserItemService, private userApi: UserApiService, private globalUser: GlobalUser) {
  }

  ngOnInit(): void {
    this.userApi.getById(this.globalUser.user.id)
      .subscribe(user => {
        this.user = user;
        }
      );
  }

  modifyCoinsAndItems(event): void {
    console.log('Coins spent : ', event.price);
    const diff = this.user.money - event.price;
    if (diff < 0) {
      console.log('No money for this');
      this.isHidden = false;
    } else {
      this.user.money -= event.price;
      // Modif user coins
      console.log(this.user.money);
      this.subscription.push(
        this.userApi.update(this.user.id, this.user)
          .subscribe()
      );
      this.isHidden = true;
      // Add item to user
      this.userItem = {
        idUser: this.globalUser.user.id,
        nameItem: event.name,
        quantity: event.quantity
      };
      this.userItemApi.getByUser(this.userItem.idUser)
        .subscribe(userItems => {
          let compteur = 0;
          userItems.forEach(item => {
            if (this.userItem.nameItem == item.nameItem) {
              this.userItem.quantity += item.quantity;
              this.subscription.push(
                this.userItemApi.update(item.id, this.userItem)
                  .subscribe()
              );
              compteur += 1;
              return;
            }
          });
          if (compteur == 0) {
            this.subscription.push(
              this.userItemApi.create(this.userItem)
                .subscribe()
            );
          }
      });
      console.log('Item ajouté : ' +
        'Id User : ' + this.userItem.idUser +
        ' - Nom :  ' + this.userItem.nameItem +
        ' - Quantité : ' + this.userItem.quantity);
    }
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }
}
