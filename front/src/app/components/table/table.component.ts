import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Cliente } from 'src/app/model/clientes';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.sass']
})
export class TableComponent implements OnInit {
  @Input() clientes: Array<Cliente> = [];
  @Output() viewVisualizacaoCliente = new EventEmitter();
  @Output() viewEditarCliente = new EventEmitter();
  @Output() clienteDelete = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

}
