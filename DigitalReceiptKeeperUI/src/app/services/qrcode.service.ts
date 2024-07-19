import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { QRcode } from '../models/qrcode.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QrcodeService {

  baseApiUrl: string = environment.baseApiUrl;


  constructor(private http:HttpClient) { }

  GetAllQRcode(): Observable<QRcode[]>{
    return this.http.get<QRcode[]>(this.baseApiUrl + 'api/QRcode/viewall');
  }

  AddQrcode(addQRcodeRequest: QRcode): Observable<QRcode>{
    addQRcodeRequest.qrCodeID = "00000000-0000-0000-0000-000000000000";
    return this.http.post<QRcode>(this.baseApiUrl + 'api/QRcode/create', addQRcodeRequest);
  }

  //show specific qrcode by qrcode id
  ShowQRcode(qrCodeID: string): Observable<QRcode> {
    return this.http.get<QRcode>(this.baseApiUrl + 'api/QRcode/fetch' + qrCodeID);
  }

  UpdateQRcode(qrCodeID:string, updateQRcodeRequest: QRcode): Observable<QRcode>{
    return this.http.put<QRcode>(this.baseApiUrl + 'api/QRcode/' + qrCodeID, updateQRcodeRequest);
  }

  DeleteQrcode(qrCodeID:string): Observable<QRcode>{
    return this.http.delete<QRcode>(this.baseApiUrl + 'api/QRcode/' + qrCodeID);
  }

  GetLatestQrcode(): Observable<QRcode>{
    return this.http.get<QRcode>(this.baseApiUrl + 'api/QRcode/latest');
  }
}
