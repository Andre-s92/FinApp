import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OperationModel } from '../models/operationModel';

@Injectable({
  providedIn: 'root',
})
export class OperationService {
  baseURL = 'http://localhost:5000/api/Operation';
  constructor(private http: HttpClient) {}

  public getOperation(): Observable<OperationModel[]> {
    return this.http.get<OperationModel[]>(this.baseURL);
  }
  public getOperationsBydescription(description: string): Observable<OperationModel[]> {
    return this.http.get<OperationModel[]>(`${this.baseURL}/OperationsBydescription/${description}`);
  }
  public getOperationById(id: number): Observable<OperationModel> {
    return this.http.get<OperationModel>(`${this.baseURL}/${id}`);
  }
  public post(evento: OperationModel): Observable<OperationModel> {
    return this.http.post<OperationModel>(this.baseURL, evento);
  }
  public put(evento: OperationModel): Observable<OperationModel> {
    return this.http.put<OperationModel>(`${this.baseURL}/${evento.id}`, evento);
  }
  public deleteOperation(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
