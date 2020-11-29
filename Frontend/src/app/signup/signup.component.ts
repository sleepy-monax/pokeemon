import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {User, Users} from '../model/user';
import {Subscription} from 'rxjs';
import {UserApiService} from '../services/user-api.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit, OnDestroy {

  user: User = null;

  pseudoPattern: string = "^[a-zA-Z0-9]{1,20}";
  emailPattern: string = "^.+@.+\\..+";
  passwordPattern: string = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\\w\\s]).{8,}$";

  player: FormGroup = this.fb.group({
    pseudo: ['', Validators.required],
    email: ['', Validators.required],
    password: ['', Validators.required],
    verifPassword: ['', Validators.required]
  });

  isDisabled: boolean = true;
  private _subscription: Subscription[] = [];
  pseudoclass: any = {
    isHidden: true
  };
  emailclass: any = {
    isHidden: true
  };

  constructor(private fb: FormBuilder, private userApi: UserApiService,
              private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy() {
    this._subscription.forEach(sub => sub && sub.unsubscribe());
  }
z
  submit() {
    this.createUser();
  }

  checkPassword() {
    if (this.player.value['verifPassword'] == this.player.value['password']) {
      this.isDisabled = false;
    } else {
      this.isDisabled = true;
    }
  }

  createUser() {
    let userEncode = {
      pseudo: this.player.value.pseudo,
      email: this.player.value.email,
      password: this.player.value.password
    };

    this._subscription.push(
      this.userApi.create(userEncode)
        .subscribe(user => {
          if (user.id != 0) {
            this.pseudoclass.isHidden = true;
            this.pseudoclass.isHidden = true;
            this.router.navigate([""]);
          }
          else {
            console.log(user)
              if (userEncode.pseudo == user.pseudo) {
                this.pseudoclass.isHidden = false;
              }else {
                this.pseudoclass.isHidden = true;
              }
              if (userEncode.email == user.email) {
                this.emailclass.isHidden = false;
              }else {
                this.emailclass.isHidden = true;
              }
          }
        })
    );
  }
}
