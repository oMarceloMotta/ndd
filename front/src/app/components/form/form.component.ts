import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from 'src/app/model/clientes';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.sass'],
})
export class FormComponent implements OnChanges {
  form: FormGroup;
  @Input() cliente: Cliente = {} as Cliente;
  @Input() title: string = "";
  @Output() salvar = new EventEmitter<Cliente>();
  @Output() editar = new EventEmitter<Cliente>();

  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      id: [this.cliente.id || ''],
      nome: [this.cliente.nome || '', Validators.required],
      cpf: [this.cliente.cpf || '', Validators.required],
      sexo: [this.cliente.sexo || '', Validators.required],
      telefone: [this.cliente.telefone || '', Validators.required],
      email: [this.cliente.email || '', [Validators.required, Validators.email]],
      dataNascimento: [this.cliente.dataNascimento || '', Validators.required],
      observacao: [this.cliente.observacao || '']
    });
  }
  ngOnChanges(): void {
    const dataFormatada = this.cliente?.dataNascimento?.toString()?.split("T")[0] || '';
    this.form = this.formBuilder.group({
      id: [this.cliente.id || ''],
      nome: [this.cliente.nome || '', Validators.required],
      cpf: [this.cliente.cpf || '', Validators.required],
      sexo: [this.cliente.sexo || '', Validators.required],
      telefone: [this.cliente.telefone || '', Validators.required],
      email: [this.cliente.email || '', [Validators.required, Validators.email]],
      dataNascimento: [dataFormatada || '', Validators.required],
      observacao: [this.cliente.observacao || '']
    });
  }
  submitForm() {
    if (this.form.valid) {
      this.cliente.id ?
        this.editar.emit(this.form.value) : this.salvar.emit(this.form.value)
    } else {
      this.marcarCamposComoTocados(this.form);
    }
  }

  marcarCamposComoTocados(formGroup: FormGroup) {
    Object.values(formGroup.controls).forEach(control => {
      if (control instanceof FormGroup) {
        this.marcarCamposComoTocados(control);
      } else {
        control.markAsTouched();
      }
    });
  }
}
