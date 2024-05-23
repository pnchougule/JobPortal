import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Admin } from '../../Services/Admin';
import { AdminService } from '../../Services/admin.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-admin',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-admin.component.html',
  styleUrl: './edit-admin.component.css'
})
export class EditAdminComponent implements OnInit{
  admin: Admin=new Admin();
  id!:any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private adminService: AdminService
  ) { }

  ngOnInit(): void {

    this.admin.joiningDate = new Date().toISOString();
    this.admin.isActive = true;
    this.admin.createdBy = 1;
    this.admin.createdOn = new Date().toISOString();
    this.admin.modifiedBy = 1;
    this.admin.modifiedOn = new Date().toISOString(); 

    this.route.paramMap.subscribe((params) => {
      this.id = params.get('id');
      console.log(this.id);
      this.getAdminById(this.id);
    });
  }

  private getAdminById(adminId:number): void {
    this.adminService.GetAdminById(adminId).subscribe(data => {
      console.log(data);
            this.admin = data;
          }, error => console.log(error));
  }

  backToAdminList(){
    this.router.navigate(['/Admin']);
  }

  updateAdmin(admin: Admin){
    console.log(admin,"admin")
    this.adminService.UpdateAdmin(admin).subscribe(data => {
      console.log(data,"datratataa");
      
    });
     this.router.navigate(['/Admin']);
  }

}