import {Component, OnInit} from '@angular/core';
import {LoginService} from "../api/login.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  showError = false;

  constructor(private service: LoginService, private router: Router) {
  }

  ngOnInit() {
  }

  submit(value) {
    this.showError = false;

    this.service.login(value.username, value.password).subscribe((success) => {
      if (success) {
        this.router.navigateByUrl('learning-program')
      } else {
        this.showError = true;
      }
    });
  }
}
