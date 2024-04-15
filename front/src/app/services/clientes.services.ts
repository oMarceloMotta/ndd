import { Observable } from 'rxjs';
import { Cliente } from '../model/clientes';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  apiUrl = environment.url + "Cliente";
  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  getClienteById(id: string): Observable<Cliente> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Cliente>(url);
  }
  updateCliente(cliente: Cliente): Observable<any> {
    const params = new HttpParams()
      .set('Id', cliente.id)
      .set('Nome', cliente.nome)
      .set('CPF', cliente.cpf)
      .set('Sexo', cliente.sexo)
      .set('Telefone', cliente.telefone)
      .set('Email', cliente.email)
      .set('DataNascimento', cliente.dataNascimento.toString())
      .set('Observacao', cliente.observacao);
    const url = `${this.apiUrl}/${cliente.id}`;
    return this.http.put(url, params);
  }
  createCliente(cliente: Cliente): Observable<Cliente> {
    const params = new HttpParams()
      .set('Nome', cliente.nome)
      .set('CPF', cliente.cpf)
      .set('Sexo', cliente.sexo)
      .set('Telefone', cliente.telefone)
      .set('Email', cliente.email)
      .set('DataNascimento', cliente.dataNascimento.toString())
      .set('Observacao', cliente.observacao);

    return this.http.post<Cliente>(this.apiUrl, null, { params });
  }
  deleteCliente(id: string): Observable<any> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete(url);
  }
}
