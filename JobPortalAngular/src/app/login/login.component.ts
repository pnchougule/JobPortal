import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Login } from '../Services/User';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  user:Login=new Login();
    
  constructor(private userService:UserService, private router: Router) {}

  backToRegister(){
    this.router.navigate(['/Register']);
  }

  login(){
    this.userService.Login(this.user).subscribe(data => {
      console.log(data);
    });
    this.router.navigate(['/Admin']);
  }
 
}
