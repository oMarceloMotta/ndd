import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'dataNascimento'
})
export class DataNascimentoPipe implements PipeTransform {
  transform(value: Date | null, format: string = 'dd/MM/yyyy'): string {
    if (!value) return '';
    const data = typeof value === 'string' ? new Date(value) : value;
    const datePipe = new DatePipe('en-US');
    return datePipe.transform(data, format) || '';
  }
}
