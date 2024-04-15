import { Component, OnInit } from '@angular/core';
import { Cliente } from '../model/clientes';
import { ClienteService } from '../services/clientes.services';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  clientes: Cliente[] = [];
  cliente: Cliente = {} as Cliente;
  isView: boolean = false;
  isEdit: boolean = false;
  titleForm: 'Cadastrar cliente' | 'Editar cliente' = 'Cadastrar cliente';
  clienteEdit: Cliente = {} as Cliente;

  constructor(private clienteService: ClienteService,
    private _snackBar: MatSnackBar
  ) { }
  ngOnInit(): void {
    this.getClientes();
  }
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 5000,
      horizontalPosition: 'end',
      verticalPosition: 'top'
    });
  }
  toggleIsView(id: string) {
    this.isView = !this.isView;
    this.isEdit = false;
    if (this.isView) {
      const cliente = this.getClienteById(id);
      console.log(cliente);
    }
  }
  toggleIsEdit(cliente: Cliente) {
    this.isEdit = !this.isEdit;
    this.isView = false;
    this.titleForm = this.isEdit ? 'Editar cliente' : 'Cadastrar cliente';
    this.cliente = cliente;
  }
  toggleBack() {
    this.isView = false;
    this.isEdit = false;
    this.titleForm = 'Cadastrar cliente';
    this.cliente = {} as Cliente;
    this.clientes = [];
    this.getClientes();
  }
  getClientes() {
    this.clienteService.getClientes().subscribe((clientes) => {
      console.log(JSON.stringify(clientes));
      this.clientes = clientes;
    },
      (error) => {
        console.error('Erro ao salvar cliente:', error);
        this.openSnackBar('Error ao salvar, tente novamente mais tarde', 'OK');
      });
  }
  getClienteById(id: string) {
    this.clienteService.getClienteById(id).subscribe((result) => {
      this.cliente = result;
    },
      (error) => {
        console.error('Erro ao salvar cliente:', error);
        this.openSnackBar('Error ao salvar, tente novamente mais tarde', 'OK');
      });
  }
  salvarClientes(cliente: Cliente) {
    this.clienteService.createCliente(cliente).subscribe((cliente) => {
      this.getClientes();
      this.openSnackBar('Cliente salvo com sucesso', 'OK');
    },
      (error) => {
        this.openSnackBar('Error ao salvar, tente novamente mais tarde', 'OK');
      })
  }
  atualizarCliente(cliente: Cliente) {
    this.clienteService.updateCliente(cliente).subscribe((cliente) => {
      this.getClientes();
    },
      (error) => {
        console.error('Erro ao Atualizar cliente:', error);
        this.openSnackBar('Error ao atualizar, tente novamente mais tarde', 'OK');
      })
  }

  deletarCliente(id: string) {
    this.clienteService.deleteCliente(id).subscribe((cliente) => {
      this.openSnackBar('Cliente deletado com sucesso', 'Ok');
      this.getClientes();
    },
      (error) => {
        console.error('Erro ao deletar cliente:', error);
        this.openSnackBar('Error ao deletar, tente novamente mais tarde', 'OK');
      })
  }
}
