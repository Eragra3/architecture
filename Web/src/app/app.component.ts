import {Component} from '@angular/core';
import {LoginService} from './api/login.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';

  isCollapsed = false;
  
  constructor(public loginService: LoginService, private router: Router) {
  }

  signOff() {
    this.loginService.signOff();
    this.router.navigateByUrl('login');
  }
}
