import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login.component';
import { RegisterComponent } from './register.component';

import { accountRouting } from './routes';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        accountRouting
    ],
    declarations: [
        AccountComponent,
        LoginComponent,
        RegisterComponent
    ],
    providers: [

    ]
})
export class AccountModule { }