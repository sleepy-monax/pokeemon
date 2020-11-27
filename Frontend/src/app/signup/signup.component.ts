import {Component, EventEmitter, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {User} from '../model/user';
import {Subscription} from 'rxjs';
import {UserApiService} from '../services/user-api.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit, OnDestroy {

  private _subscription: Subscription[] = [];

  player: FormGroup = this.fb.group({
    pseudo: ['', Validators.required],
    email: ['', Validators.required],
    password: ['', Validators.required],
    verifPassword: ['', Validators.required]
  });
  isDisabled: boolean = true;

  constructor(private fb: FormBuilder, private userApi: UserApiService) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    this._subscription.forEach(sub => sub && sub.unsubscribe());
  }

  submit() {
    this.createUser();
    this.player.reset();
  }

  checkPassword() {
    if (this.player.value['verifPassword'] == this.player.value['password']) {
      this.isDisabled = false;
    }
    else {
      this.isDisabled = true;
    }
  }

  createUser() {
    let user = {
      pseudo: this.player.value.pseudo,
      email: this.player.value.email,
      password: this.player.value.password
    };
    this._subscription.push(
      this.userApi.create(user)
        .subscribe()
    );
  }
}
