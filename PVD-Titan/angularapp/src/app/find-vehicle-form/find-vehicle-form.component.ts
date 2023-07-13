import { Component } from '@angular/core';
import { DatabaseService } from '../database.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-find-vehicle-form',
  templateUrl: './find-vehicle-form.component.html',
  styleUrls: ['./find-vehicle-form.component.css']
})
export class FindVehicleFormComponent {
  retrievedData: any; // Adjust the type according to the structure of your retrieved data

  yearOfManufacture: string = '';
  vehicleMake: string = '';
  vehicleModel: string = '';
  
  data?:any;
  error?:any;

  constructor(private databaseService: DatabaseService) {}

  submitForm() {
    this.databaseService.queryDatabase(this.yearOfManufacture, this.vehicleMake, this.vehicleModel)
      .subscribe(
        (data) => {
          console.log(data);  
          this.retrievedData = data;       },
        (error) => {
          // Handle errors
        }
      );
  }
}
