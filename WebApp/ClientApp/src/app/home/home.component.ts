import { Component } from '@angular/core';
import {HttpClient, HttpEventType, HttpRequest} from "@angular/common/http";
import {PaySlipVm} from "../../models/PaySlipVm";
import {Ng4SpinnerService} from "ng4-spinner";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent {

  public progress: number;
  public payList:PaySlipVm[]=[];

  constructor(public  http:HttpClient,private ngSpinner:Ng4SpinnerService){

  }
  public upload(files:any) {
    if (files.length === 0)
      return;

    const formData = new FormData();
    this.ngSpinner.show();

    for (let file of files)
      formData.append(file.name, file);

    const uploadReq = new HttpRequest('POST', `api/salary`, formData, {
      reportProgress: true,
    });
    this.http.request<any[]>(uploadReq).subscribe(event =>
    {
      if(event)
      {
        if (event.type === HttpEventType.UploadProgress && (event.total))
        {
          this.progress = Math.round(100 * event.loaded / event.total);
        }
        else if (event.type === HttpEventType.Response && event.body){
           event.body.map(w=>{
              this.payList.push({Id:w.id,
               IncomeTax:w.incomeTax,
               Name:w.name,
               NetIncome:w.netIncome,
               Super:w.super,
               GrossIncome:w.grossIncome,
               PayPeriod:w.payPeriod})
           });
          this.ngSpinner.hide()
        }
      }
    });
  };
}
