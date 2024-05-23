import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../Services/admin.service';
import { Admin } from '../../Services/Admin';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-admin',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-admin.component.html',
  styleUrls: ['./add-admin.component.css']  // Correct the metadata key
})
export class AddAdminComponent implements OnInit{
  admin:Admin=new Admin();
  
  
  constructor(private adminService:AdminService, private router: Router) {}

  ngOnInit(): void {
    this.admin.joiningDate = new Date().toISOString();
    this.admin.isActive = true;
    this.admin.createdBy = 1;
    this.admin.createdOn = new Date().toISOString();
    this.admin.modifiedBy = 1;
    this.admin.modifiedOn = new Date().toISOString();
  }

  backToAdminList(){
    this.router.navigate(['/Admin']);
  }

  saveAdmin(){
    console.log(this.admin);
    this.adminService.AddAdmin(this.admin).subscribe(data => {
      console.log(data);
      this.adminService.GetAllAdmins();
    });
    this.router.navigate(['/Admin']);
  }
 
}