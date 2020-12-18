import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {User} from '../../model/user';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthenticationService} from '../../services/authentication.service';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.less']
})
export class SigninComponent implements OnInit {

  @Input()
  userVerified: EventEmitter<User> = new EventEmitter<User>();

  player: FormGroup = this.fb.group({
    pseudo: ['', Validators.required],
    password: ['', Validators.required],
  });

  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private router: Router,
              private authenticationService: AuthenticationService) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
    // get return url from route parameters or default to '/'
    this.returnUrl = '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.player.controls; }

  submit() {
    //this.userVerified.emit(this.player.value);
    //this.player.reset();
    this.submitted = true;

    // stop here if form is invalid
    if (this.player.invalid) {
      return;
    }

    this.loading = true;
    this.authenticationService.login(this.f.pseudo.value, this.f.password.value)
      .pipe(first())
      .subscribe(
        data => {
          if (data.id != 0) {
            this.router.navigate(['']);
          } else {
            this.player.reset();
          }
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }
}
