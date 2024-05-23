import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Admin } from '../../Services/Admin';
import { AdminService } from '../../Services/admin.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink],
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  admins!: Admin[];

  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit(): void {
    this.getAdmins();
  }

   getAdmins(): void {
    this.adminService.GetAllAdmins().subscribe(data => {
      this.admins = data;
    });
  }

  GetAdminById(adminId: number): void {
    this.router.navigate(['/app-edit-admin', adminId]);
  }

  deleteAdmin(adminId: number): void {
    this.adminService.DeleteAdmin(adminId).subscribe(data => {
      console.log(data);
       this.getAdmins();
    });
  }
  updateAdmin(adminId: number) {
    console.log("Id to update: ",adminId);
    this.router.navigate(['/update-admin', adminId]); // Navigate to the edit route with admin ID as parameter
  }
  addAdmin(){
    this.router.navigate(['/addAdmin']);
  }

}
