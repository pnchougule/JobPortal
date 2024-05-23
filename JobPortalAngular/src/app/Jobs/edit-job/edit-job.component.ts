import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { JobService } from '../../Services/job.service';
import { Job } from '../../Services/Job';

@Component({
  selector: 'app-edit-job',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './edit-job.component.html',
  styleUrl: './edit-job.component.css'
})

export class EditJobComponent implements OnInit{
  job: Job=new Job();
  id!:any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private jobService: JobService
  ) { }

  ngOnInit(): void {

    this.job.postedDate = new Date().toISOString();
    this.job.isActive = true;
    this.job.createdBy = 1;
    this.job.createdOn = new Date().toISOString();
    this.job.modifiedBy = 1;
    this.job.modifiedOn = new Date().toISOString(); 

    this.route.paramMap.subscribe((params) => {
      this.id = params.get('id');
      console.log(this.id);
      this.getJobById(this.id);
    });
  }

  private getJobById(id:number): void {
    this.jobService.GetJdById(id).subscribe(data => {
      console.log(data);
            this.job = data;
          }, error => console.log(error));
  }

  backToJobList(){
    this.router.navigate(['/Job']);
  }

  updateJob(job: Job){
    this.jobService.UpdateJd(job).subscribe(data => {
      console.log(data);
      this.jobService.GetAllJds();
    });
    this.router.navigate(['/Job']);
  }

}