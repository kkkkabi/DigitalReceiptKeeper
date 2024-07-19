import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Receipt } from '../models/recepit.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ReceiptService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http:HttpClient) { }

  GetAllReceipt(): Observable<Receipt[]>{
    return this.http.get<Receipt[]>(this.baseApiUrl + 'api/Receipt/viewall');
  }

  // AddReceipt(addReceiptRequest:Receipt): Observable<Receipt>{
  //   addReceiptRequest.receiptDate = addReceiptRequest.receiptDate.toISOString();
  //   addReceiptRequest.receiptID = "00000000-0000-0000-0000-000000000000";
  //   return this.http.post<Receipt>(this.baseApiUrl + 'api/Receipt/create', addReceiptRequest);
  // }

  AddReceipt(addReceiptRequest: Receipt): Observable<Receipt> {
    const requestWithISODate = { ...addReceiptRequest, receiptDate: new Date(addReceiptRequest.receiptDate) };
    requestWithISODate.receiptID = "00000000-0000-0000-0000-000000000000";
    return this.http.post<Receipt>(this.baseApiUrl + 'api/Receipt/create', requestWithISODate);
  }
  

  // AddReceipt(addReceiptRequest: Receipt): Observable<Receipt>{
  //   addReceiptRequest.receiptID = "00000000-0000-0000-0000-000000000000";
  //   return this.http.post<Receipt>(this.baseApiUrl + 'api/Receipt/create', addReceiptRequest);
  // }

  //show specific receipt
  ShowReceipt(receiptID: string): Observable<Receipt> {
    return this.http.get<Receipt>(this.baseApiUrl + 'api/Receipt/fetch/' + receiptID);
  }

  UpdateReceipt(receiptID:string, updateReceiptRequest: Receipt): Observable<Receipt>{
    return this.http.put<Receipt>(this.baseApiUrl + 'api/Receipt/' + receiptID, updateReceiptRequest);
  }

  DeleteReceipt(receiptID:string): Observable<Receipt>{
    return this.http.delete<Receipt>(this.baseApiUrl + 'api/Receipt/' + receiptID);
  }


}
