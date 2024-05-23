import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Register } from '../Services/User';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent implements OnInit {
  user: Register = new Register();

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.user.createAt = new Date().toISOString();
  }

  backToLogin() {
    this.router.navigate(['/Login']);
  }

  register() {
    console.log(this.user);
      this.userService.Register(this.user).subscribe(data => {
        console.log(data);
      this.router.navigate(['/Login']);
    });
  }

}
