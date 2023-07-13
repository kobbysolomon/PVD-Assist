import { Component } from '@angular/core';
import { DatabaseService } from '../database.service';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

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
  error?: any;

  public packages?: PackageDefault[];

  constructor(private http: HttpClient) { }

  onSubmit() {
    this.http.get<PackageDefault[]>("/form").subscribe(
      result => {
        this.packages = result;
      }, error => console.error(error));
  }
  
}
interface PackageDefault {
  pkg_id: number,
  pkg_length: number,
  pkg_width: number,
  pkg_height: number,
  pkg_volume: number,
  pkg_type: string
}

