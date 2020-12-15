import { Component, OnInit } from '@angular/core';
// @ts-ignore
import itemsJson from '../../../../../Assets/items.json';
import { Observable, Subscription } from 'rxjs';
import { Item } from 'src/model/item';
import { UserItemService } from 'src/app/services/user-item-service';
import { UserApiService } from 'src/app/services/user-api.service';
import { User } from 'src/app/model/user';
import { UserItem } from 'src/app/model/user-item';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.less']
})
export class ShopComponent implements OnInit {

  items: Item[] = itemsJson;
  userItem: UserItem = null;
  user: User = null;
  id: number = 1;

  private _subscription: Subscription[] = [];

  quantity: number = 1;
  coins: number = 0;
  isHidden: boolean = true;

  constructor(private userItemApi: UserItemService, private userApi: UserApiService) {
  }

  ngOnInit(): void {
    this.userApi.getById(this.id)
      .subscribe(user => {
        this.coins = user.money;
        }
      );
  }

  modifyCoinsAndItems(event) {
    console.log("Coins spent : ", event.price);
    var diff = this.coins - event.price;
    if (diff < 0) {
      console.log("No money for this");
      this.isHidden = false;
      return;
    } else {
      this.coins -= event.price;
      //Modif user coins
      this.userApi.getById(this.id)
        .subscribe(userGet => {
            this.user = userGet;
            console.log("avant update : " + this.user.money);
            userGet.money = this.coins;

            console.log(this.user);
            this.userApi.update(userGet.id, this.user);
            console.log("après update : " + this.user.money);
          }
        );
      this.isHidden = true;
      //Add item to user
      this.userItem = {
        idUser: this.id,
        nameItem: event.name,
        quantity: event.quantity
      };
      this.userItemApi.getById(this.id)
        .subscribe(userItem => {
          const userItemTest = userItem;
          console.log("User test : " + userItemTest);
        });
      this._subscription.push(
        this.userItemApi.create(this.userItem)
          .subscribe()
      );
      console.log("Item ajouté : " +
        "Id User : " + this.userItem.idUser +
        " - Nom :  " + this.userItem.nameItem +
        " - Quantité : " + this.userItem.quantity);
    }
  }

  ngOnDestroy() {
    this._subscription.forEach(sub => sub && sub.unsubscribe());
  }


}
