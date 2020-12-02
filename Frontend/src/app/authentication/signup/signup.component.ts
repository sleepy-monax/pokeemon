import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/model/user';
import { UserApiService } from 'src/app/services/user-api.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.less']
})
export class SignupComponent implements OnInit, OnDestroy {

  user: User = null;

  pseudoPattern: string = '^[a-zA-Z0-9]{1,20}';
  emailPattern: string = '^.+@.+\\..+';
  passwordPattern: string = '^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^\\w\\s]).{8,}$';

  player: FormGroup = this.fb.group({
    pseudo: ['', Validators.required],
    email: ['', Validators.required],
    password: ['', Validators.required],
    verifPassword: ['', Validators.required]
  });

  isDisabled = true;
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

  ngOnDestroy(): void {
    this._subscription.forEach(sub => sub && sub.unsubscribe());
  }

  submit(): void {
    this.createUser();
  }

  checkPassword(): void {
    if (this.player.value.verifPassword === this.player.value.password) {
      this.isDisabled = false;
    } else {
      this.isDisabled = true;
    }
  }

  createUser(): void {
    const userEncode = {
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
            } else {
              this.pseudoclass.isHidden = true;
            }
            if (userEncode.email == user.email) {
              this.emailclass.isHidden = false;
            } else {
              this.emailclass.isHidden = true;
            }
          }
        })
    );
  }
}
