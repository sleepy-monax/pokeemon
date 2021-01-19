import {Component, OnDestroy, OnInit} from '@angular/core';
import {User} from '../../model/user';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Subscription} from 'rxjs';
import {UserApiService} from '../../services/user-api.service';
import {GlobalUser} from '../../helpers/global-user';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.less']
})
export class AccountComponent implements OnInit, OnDestroy {
  user: User;
  id: number;

  pseudoclass: any = {
    isHidden: true
  };
  emailclass: any = {
    isHidden: true
  };

  pseudoPattern = '^[a-zA-Z0-9]{1,20}';
  emailPattern = '^.+@.+\\..+';

  player;
  isDisabled: boolean;

  subscription: Subscription[] = [];

  constructor(private fb: FormBuilder,
              private userApi: UserApiService,
              private globalUser: GlobalUser) {
  }

  ngOnInit(): void {
    this.subscription.push(
      this.userApi.getById(JSON.parse(localStorage.getItem('currentUser')).id)
        .subscribe( user => {
          this.user = user;
          if (user != null) {
            this.player = this.fb.group({
              pseudo: [user.pseudo, Validators.required],
              email: [user.email, Validators.required],
              password: ['', Validators.required],
              confirmPassword: ['', Validators.required]
            });
          }
        }
      )
    );
  }

  ngOnDestroy(): void {
    this.subscription.forEach(sub => sub && sub.unsubscribe());
  }

  submit(): void {
    if (this.user == this.player.value) {
      return;
    }

    this.user = this.player.value;
    this.user.id = this.globalUser.user.id;

    this.subscription.push(
      this.userApi.update(this.user.id, this.user)
        .subscribe()
    );
  }

  checkPassword(): void {
    if (this.player.value.confirmPassword === this.player.value.password) {
      this.isDisabled = false;
    } else {
      this.isDisabled = true;
    }
  }

}
