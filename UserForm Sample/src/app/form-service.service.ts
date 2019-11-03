import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FormServiceService {
  //endpoint = 'http://localhost:8080/PLMPortalService/api/';
  endpoint = 'http://localhost:5000/api/client'
  networkData = new BehaviorSubject([]);

  status = false;
  jsonData = [];
  finalJsonData = {};

  constructor(private httpClient: HttpClient) {

  }

  commonService() {
    return this.httpClient.get<any>(this.endpoint).subscribe(data => {
      if (data != '' && data != null) {
        data;
      }
    })
  }

  providerData() {
    return this.httpClient.get<any>(this.endpoint)
  }

  saveData(data) {
    // this.status = true;
    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     'Content-Type': 'application/json'
    //   })
    // };

    
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'text/html; charset=UTF-8s');
    headers.append('Access-Control-Allow-Origin','*');
    // console.log(this.finalJsonData);
    // debugger;
    // this.httpClient.post<any>(this.endpoint,this.finalJsonData,httpOptions).subscribe(data=>{
    //     console.log(this.finalJsonData)
    //   })

    this.finalJsonData = JSON.stringify(data);
    this.httpClient.post<any>(this.endpoint, data, { headers: headers }).subscribe();
  }




}

