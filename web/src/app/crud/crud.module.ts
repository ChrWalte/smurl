import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClipboardModule } from 'ngx-clipboard';

import { CrudRoutingModule } from './routing/crud-routing.module';
import { CreateComponent } from './create/create.component';

@NgModule({
  declarations: [CreateComponent],
  imports: [
    CommonModule,
    CrudRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    ClipboardModule,
  ],
  exports: [],
  providers: [],
  bootstrap: [],
})
export class CrudModule {}
