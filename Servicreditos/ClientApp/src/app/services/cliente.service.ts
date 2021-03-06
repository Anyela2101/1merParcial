import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable,pipe, from } from 'rxjs';
import { Cliente } from '../Credito/models/cliente';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  baseUrl:string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService)
   { 
     this.baseUrl=baseUrl;
   }

   get(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.baseUrl + 'api/cliente')
    .pipe(
     tap(_ => this.handleErrorService.log('datos enviados')),
     catchError(this.handleErrorService.handleError<Cliente[]>('Consultar Cliente', null))
    );
   }

   post(cliente:Cliente): Observable<Cliente>{
    return this.http.post<Cliente>(this.baseUrl + 'api/Cliente', cliente)
    .pipe(
      tap(_ => this.handleErrorService.log('datos enviados')),
      catchError(this.handleErrorService.handleError<Cliente>('Registrar Cliente', null))
    );
  }
}
