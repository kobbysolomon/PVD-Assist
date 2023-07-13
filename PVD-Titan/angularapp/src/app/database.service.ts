import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConnectionPool, config } from 'mssql';

const dbConfig = {
  user: 'CloudSAd62f4aff',
  password: 'TechTitans#123',
  server: 'techtitans.database.windows.net',
  database: 'TechTitansData (techtitans/TechTitansData)',
  options: {
    encrypt: true, // Enable encryption for secure connection (recommended)
    trustServerCertificate: true, // Trust the server certificate (recommended for development/testing purposes only)
  },
};

@Injectable({
  providedIn: 'root'
})



export class DatabaseService {

  
  

  private apiUrl = 'https://pvd-titan-apim.azure-api.net'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}
  queryDatabase(yearOfManufacture: string, vehicleMake: string, vehicleModel: string) {
    const queryParams = {
      year_of_manufacture: yearOfManufacture,
      vehicle_make: vehicleMake,
      vehicle_model: vehicleModel
    };

    return this.http.get<any>(`${this.apiUrl}/query`, { params: queryParams });
  }

}
