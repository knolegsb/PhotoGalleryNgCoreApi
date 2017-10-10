System.register(['@angular/router', './account.component', './login.component', './register.component'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, account_component_1, login_component_1, register_component_1;
    var accountRoutes, accountRouting;
    return {
        setters:[
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (account_component_1_1) {
                account_component_1 = account_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (register_component_1_1) {
                register_component_1 = register_component_1_1;
            }],
        execute: function() {
            exports_1("accountRoutes", accountRoutes = [
                {
                    path: 'account',
                    component: account_component_1.AccountComponent,
                    children: [
                        { path: 'register', component: register_component_1.RegisterComponent },
                        { path: 'login', component: login_component_1.LoginComponent }
                    ]
                }
            ]);
            exports_1("accountRouting", accountRouting = router_1.RouterModule.forChild(accountRoutes));
        }
    }
});
//# sourceMappingURL=routes.js.map