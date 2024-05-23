import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Job } from '../../Services/Job';
import { JobService } from '../../Services/job.service';

@Component({
  selector: 'app-add-job',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-job.component.html',
  styleUrl: './add-job.component.css'
})
export class AddJobComponent implements OnInit{
  job:Job=new Job();
  
  
  constructor(private jobService:JobService, private router: Router) {}

  ngOnInit(): void {
    this.job.postedDate = new Date().toISOString();
    this.job.isActive = true;
    this.job.createdBy = 1;
    this.job.createdOn = new Date().toISOString();
    this.job.modifiedBy = 1;
    this.job.modifiedOn = new Date().toISOString();
  }

  backToJobList(){
    this.router.navigate(['/Job']);
  }

  saveJob(){
    console.log(this.job);
    this.job.experience = Number(this.job.experience);
    this.jobService.AddJd(this.job).subscribe(data => {
      console.log(data);
      this.jobService.GetAllJds();
    });
    this.router.navigate(['/Job']);
  }
 
}