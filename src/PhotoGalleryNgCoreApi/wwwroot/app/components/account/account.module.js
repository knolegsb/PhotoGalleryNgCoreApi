System.register(['@angular/core', '@angular/forms', '@angular/common', './account.component', './login.component', './register.component', './routes'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, forms_1, common_1, account_component_1, login_component_1, register_component_1, routes_1;
    var AccountModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (common_1_1) {
                common_1 = common_1_1;
            },
            function (account_component_1_1) {
                account_component_1 = account_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (register_component_1_1) {
                register_component_1 = register_component_1_1;
            },
            function (routes_1_1) {
                routes_1 = routes_1_1;
            }],
        execute: function() {
            AccountModule = class AccountModule {
            };
            AccountModule = __decorate([
                core_1.NgModule({
                    imports: [
                        common_1.CommonModule,
                        forms_1.FormsModule,
                        routes_1.accountRouting
                    ],
                    declarations: [
                        account_component_1.AccountComponent,
                        login_component_1.LoginComponent,
                        register_component_1.RegisterComponent
                    ],
                    providers: []
                }), 
                __metadata('design:paramtypes', [])
            ], AccountModule);
            exports_1("AccountModule", AccountModule);
        }
    }
});
//# sourceMappingURL=account.module.js.map