import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'telefone'
})
export class TelefonePipe implements PipeTransform {
  transform(value: string): string {
    if (!value) return value;

    // Remove todos os caracteres não numéricos
    const numericValue = value.replace(/\D/g, '');

    // Formatação do telefone (##) #####-####
    return `(${numericValue.substring(0, 2)}) ${numericValue.substring(2, 7)}-${numericValue.substring(7, 11)}`;
  }
}
