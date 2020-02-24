(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./$$_lazy_route_resource lazy recursive":
/*!******************************************************!*\
  !*** ./$$_lazy_route_resource lazy namespace object ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html":
/*!**************************************************************************!*\
  !*** ./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html ***!
  \**************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = ("<br/>\r\n\r\n<div class=\"container-fluid\">\r\n  <div class=\"row\">\r\n    <div class=\"col-sm\">\r\n      <div class=\"card\">\r\n        <div class=\"card-header\">\r\n          Lobby ({{lobby.length}})\r\n        </div> <!--card header-->\r\n        <table class=\"table table-sm table-hover\"><tbody>\r\n          <tr class=\"d-flex\" *ngFor='let player of lobby; index as i'>\r\n            <th class=\"col-1\" scope=\"row\">{{i+1}}</th>\r\n            <td class=\"col-1\"><button class=\"text-danger\" (click)=\"removeFromLobby(player)\">X</button></td>\r\n            <td class=\"col-1\"><button class=\"text-primary\" *ngIf=\"team1.length < 8\" (click)=\"lobbyToTeam1(player)\">1</button></td>\r\n            <td class=\"col-1\"><button class=\"text-success\" *ngIf=\"team2.length < 8\" (click)=\"lobbyToTeam2(player)\">2</button></td>\r\n            <td class=\"col-3\"><span [ngClass]=\"{'text-muted' : player.pos > 16}\">{{player.name}}</span></td>\r\n            <td class=\"col-5\"><span *ngFor='let role of player.pref'><img src=\"./assets/{{role}}.png\" /></span></td>\r\n          </tr>\r\n        </tbody></table>\r\n      </div> <!--card-->\r\n    </div> <!--col-->\r\n\r\n    <div class=\"col-sm\">\r\n\r\n      <div class=\"card\">\r\n        <div class=\"card-header text-white bg-primary\">\r\n          Team 1 ({{team1.length}}/8)&nbsp;\r\n          <button class=\"text-danger\"  *ngIf=\"team1.length > 0\" (click)=\"team1Clear()\">X</button>&nbsp;\r\n          <button class=\"text-warning\" *ngIf=\"(team1.length == 8) && (team2.length == 8)\" (click)=\"team1Win()\">WIN</button>\r\n        </div> <!--card header-->\r\n        <table class=\"table table-sm table-hover text-primary\"><tbody>\r\n          <tr class=\"d-flex\" *ngFor='let player of team1; index as i'>\r\n            <td class=\"col-1\"><button class=\"text-danger\" (click)=\"team1ToLobby(player)\">X</button></td>\r\n            <td class=\"col-1\"> <button class=\"text-success\" *ngIf=\"team2.length < 8\" (click)=\"team1ToTeam2(player)\">↓</button></td>\r\n            <td class=\"col-3\">{{player.name}}</td>\r\n            <td class=\"col-7\"><span class=\"role-selector\" *ngFor=\"let r of enum_roles\"><input type=\"radio\" name=\"a{{i}}-role\" id=\"a{{i}}-{{r}}\" value=\"{{r}}\" (click)=\"setRole(player, r, 1)\" /><label class=\"role {{r}}\" for=\"a{{i}}-{{r}}\"></label>&nbsp;</span></td>\r\n          </tr>\r\n        </tbody></table>\r\n      </div> <!--card-->\r\n\r\n      <br />\r\n\r\n      <div class=\"card\">\r\n        <div class=\"card-header text-white bg-success\">\r\n          Team 2 ({{team2.length}}/8)&nbsp;\r\n          <button class=\"text-danger\"  *ngIf=\"team2.length > 0\" (click)=\"team2Clear()\">X</button>&nbsp;\r\n          <button class=\"text-warning\" *ngIf=\"(team1.length == 8) && (team2.length == 8)\" (click)=\"team2Win()\">WIN</button>\r\n        </div>\r\n        <table class=\"table table-sm table-hover text-success\"><tbody>\r\n          <tr class=\"d-flex\" *ngFor='let player of team2; index as i'>\r\n            <td class=\"col-1\"><button class=\"text-danger\" (click)=\"team2ToLobby(player)\">X</button></td>\r\n            <td class=\"col-1\"><button class=\"text-primary\" *ngIf=\"team1.length < 8\" (click)=\"team2ToTeam1(player)\">↑</button></td>\r\n            <td class=\"col-3\">{{player.name}}</td>\r\n            <td class=\"col-7\"><span class=\"role-selector\" *ngFor=\"let r of enum_roles\"><input type=\"radio\" name=\"b{{i}}-role\" id=\"b{{i}}-{{r}}\" value=\"{{r}}\" (click)=\"setRole(player, r, 2)\" /><label class=\"role {{r}}\" for=\"b{{i}}-{{r}}\"></label>&nbsp;</span></td>\r\n          </tr>\r\n        </tbody></table>\r\n      </div> <!--card-->\r\n\r\n    </div> <!--col-->\r\n\r\n    <div class=\"col-sm\">\r\n      <div class=\"card\">\r\n        <div class=\"card-header\">\r\n          History\r\n        </div> <!--card header-->\r\n        <table class=\"table table-sm\"><tbody>\r\n          <tr *ngFor='let entry of history'><td>{{entry}}</td></tr>\r\n        </tbody></table>\r\n      </div> <!--card-->\r\n    </div> <!--col-->\r\n  </div> <!--row-->\r\n  \r\n</div> <!--container-->\n\n<router-outlet></router-outlet>\n");

/***/ }),

/***/ "./node_modules/tslib/tslib.es6.js":
/*!*****************************************!*\
  !*** ./node_modules/tslib/tslib.es6.js ***!
  \*****************************************/
/*! exports provided: __extends, __assign, __rest, __decorate, __param, __metadata, __awaiter, __generator, __exportStar, __values, __read, __spread, __spreadArrays, __await, __asyncGenerator, __asyncDelegator, __asyncValues, __makeTemplateObject, __importStar, __importDefault, __classPrivateFieldGet, __classPrivateFieldSet */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__extends", function() { return __extends; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__assign", function() { return __assign; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__rest", function() { return __rest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__decorate", function() { return __decorate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__param", function() { return __param; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__metadata", function() { return __metadata; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__awaiter", function() { return __awaiter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__generator", function() { return __generator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__exportStar", function() { return __exportStar; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__values", function() { return __values; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__read", function() { return __read; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__spread", function() { return __spread; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__spreadArrays", function() { return __spreadArrays; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__await", function() { return __await; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncGenerator", function() { return __asyncGenerator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncDelegator", function() { return __asyncDelegator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__asyncValues", function() { return __asyncValues; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__makeTemplateObject", function() { return __makeTemplateObject; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__importStar", function() { return __importStar; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__importDefault", function() { return __importDefault; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__classPrivateFieldGet", function() { return __classPrivateFieldGet; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "__classPrivateFieldSet", function() { return __classPrivateFieldSet; });
/*! *****************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License"); you may not use
this file except in compliance with the License. You may obtain a copy of the
License at http://www.apache.org/licenses/LICENSE-2.0

THIS CODE IS PROVIDED ON AN *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
MERCHANTABLITY OR NON-INFRINGEMENT.

See the Apache Version 2.0 License for specific language governing permissions
and limitations under the License.
***************************************************************************** */
/* global Reflect, Promise */

var extendStatics = function(d, b) {
    extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return extendStatics(d, b);
};

function __extends(d, b) {
    extendStatics(d, b);
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
}

var __assign = function() {
    __assign = Object.assign || function __assign(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p)) t[p] = s[p];
        }
        return t;
    }
    return __assign.apply(this, arguments);
}

function __rest(s, e) {
    var t = {};
    for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
        t[p] = s[p];
    if (s != null && typeof Object.getOwnPropertySymbols === "function")
        for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) {
            if (e.indexOf(p[i]) < 0 && Object.prototype.propertyIsEnumerable.call(s, p[i]))
                t[p[i]] = s[p[i]];
        }
    return t;
}

function __decorate(decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
}

function __param(paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
}

function __metadata(metadataKey, metadataValue) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(metadataKey, metadataValue);
}

function __awaiter(thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
}

function __generator(thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
}

function __exportStar(m, exports) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}

function __values(o) {
    var s = typeof Symbol === "function" && Symbol.iterator, m = s && o[s], i = 0;
    if (m) return m.call(o);
    if (o && typeof o.length === "number") return {
        next: function () {
            if (o && i >= o.length) o = void 0;
            return { value: o && o[i++], done: !o };
        }
    };
    throw new TypeError(s ? "Object is not iterable." : "Symbol.iterator is not defined.");
}

function __read(o, n) {
    var m = typeof Symbol === "function" && o[Symbol.iterator];
    if (!m) return o;
    var i = m.call(o), r, ar = [], e;
    try {
        while ((n === void 0 || n-- > 0) && !(r = i.next()).done) ar.push(r.value);
    }
    catch (error) { e = { error: error }; }
    finally {
        try {
            if (r && !r.done && (m = i["return"])) m.call(i);
        }
        finally { if (e) throw e.error; }
    }
    return ar;
}

function __spread() {
    for (var ar = [], i = 0; i < arguments.length; i++)
        ar = ar.concat(__read(arguments[i]));
    return ar;
}

function __spreadArrays() {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};

function __await(v) {
    return this instanceof __await ? (this.v = v, this) : new __await(v);
}

function __asyncGenerator(thisArg, _arguments, generator) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var g = generator.apply(thisArg, _arguments || []), i, q = [];
    return i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i;
    function verb(n) { if (g[n]) i[n] = function (v) { return new Promise(function (a, b) { q.push([n, v, a, b]) > 1 || resume(n, v); }); }; }
    function resume(n, v) { try { step(g[n](v)); } catch (e) { settle(q[0][3], e); } }
    function step(r) { r.value instanceof __await ? Promise.resolve(r.value.v).then(fulfill, reject) : settle(q[0][2], r); }
    function fulfill(value) { resume("next", value); }
    function reject(value) { resume("throw", value); }
    function settle(f, v) { if (f(v), q.shift(), q.length) resume(q[0][0], q[0][1]); }
}

function __asyncDelegator(o) {
    var i, p;
    return i = {}, verb("next"), verb("throw", function (e) { throw e; }), verb("return"), i[Symbol.iterator] = function () { return this; }, i;
    function verb(n, f) { i[n] = o[n] ? function (v) { return (p = !p) ? { value: __await(o[n](v)), done: n === "return" } : f ? f(v) : v; } : f; }
}

function __asyncValues(o) {
    if (!Symbol.asyncIterator) throw new TypeError("Symbol.asyncIterator is not defined.");
    var m = o[Symbol.asyncIterator], i;
    return m ? m.call(o) : (o = typeof __values === "function" ? __values(o) : o[Symbol.iterator](), i = {}, verb("next"), verb("throw"), verb("return"), i[Symbol.asyncIterator] = function () { return this; }, i);
    function verb(n) { i[n] = o[n] && function (v) { return new Promise(function (resolve, reject) { v = o[n](v), settle(resolve, reject, v.done, v.value); }); }; }
    function settle(resolve, reject, d, v) { Promise.resolve(v).then(function(v) { resolve({ value: v, done: d }); }, reject); }
}

function __makeTemplateObject(cooked, raw) {
    if (Object.defineProperty) { Object.defineProperty(cooked, "raw", { value: raw }); } else { cooked.raw = raw; }
    return cooked;
};

function __importStar(mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result.default = mod;
    return result;
}

function __importDefault(mod) {
    return (mod && mod.__esModule) ? mod : { default: mod };
}

function __classPrivateFieldGet(receiver, privateMap) {
    if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to get private field on non-instance");
    }
    return privateMap.get(receiver);
}

function __classPrivateFieldSet(receiver, privateMap, value) {
    if (!privateMap.has(receiver)) {
        throw new TypeError("attempted to set private field on non-instance");
    }
    privateMap.set(receiver, value);
    return value;
}


/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");



const routes = [];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
    })
], AppRoutingModule);



/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony default export */ __webpack_exports__["default"] = (".role-selector input {\r\n  margin: 0;\r\n  padding: 0;\r\n  -webkit-appearance: none;\r\n  -moz-appearance: none;\r\n  /*appearance: none;*/\r\n}\r\n\r\n.w    { background-image: url('w.png'); }\r\n\r\n.d    { background-image: url('d.png'); }\r\n\r\n.a    { background-image: url('a.png'); }\r\n\r\n.p    { background-image: url('p.png'); }\r\n\r\n.r    { background-image: url('r.png'); }\r\n\r\n.e    { background-image: url('e.png'); }\r\n\r\n.n    { background-image: url('n.png'); }\r\n\r\n.me   { background-image: url('me.png'); }\r\n\r\n.prot { background-image: url('prot.png'); }\r\n\r\n.heal { background-image: url('heal.png'); }\r\n\r\n.rt   { background-image: url('rt.png'); }\r\n\r\n.role-selector input:active + .role {\r\n  opacity: .9;\r\n}\r\n\r\n.role-selector input:checked + .role {\r\n  -webkit-filter: none;\r\n  -moz-filter: none;\r\n  filter: none;\r\n}\r\n\r\n.role {\r\n  cursor: pointer;\r\n  background-size: contain;\r\n  background-repeat: no-repeat;\r\n  display: inline-block;\r\n  width: 20px;\r\n  height: 20px;\r\n  /*-webkit-transition: all 100ms ease-in;\r\n  -moz-transition: all 100ms ease-in;\r\n  transition: all 100ms ease-in;*/\r\n  -webkit-filter: brightness(0.5) grayscale(1);\r\n  -moz-filter:    brightness(0.5) grayscale(1);\r\n  filter:         brightness(0.5) grayscale(1);\r\n}\r\n\r\n.role:hover {\r\n  -webkit-filter: brightness(1.50) grayscale(0.5);\r\n  -moz-filter:    brightness(1.50) grayscale(0.5);\r\n  filter:         brightness(1.50) grayscale(0.5);\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvYXBwLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxTQUFTO0VBQ1QsVUFBVTtFQUNWLHdCQUF3QjtFQUN4QixxQkFBcUI7RUFDckIsb0JBQW9CO0FBQ3RCOztBQUVBLFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsOEJBQXdDLEVBQUU7O0FBQ2xELFFBQVEsK0JBQXlDLEVBQUU7O0FBQ25ELFFBQVEsaUNBQTJDLEVBQUU7O0FBQ3JELFFBQVEsaUNBQTJDLEVBQUU7O0FBQ3JELFFBQVEsK0JBQXlDLEVBQUU7O0FBRW5EO0VBQ0UsV0FBVztBQUNiOztBQUVBO0VBQ0Usb0JBQW9CO0VBQ3BCLGlCQUFpQjtFQUNqQixZQUFZO0FBQ2Q7O0FBRUE7RUFDRSxlQUFlO0VBQ2Ysd0JBQXdCO0VBQ3hCLDRCQUE0QjtFQUM1QixxQkFBcUI7RUFDckIsV0FBVztFQUNYLFlBQVk7RUFDWjs7aUNBRStCO0VBQy9CLDRDQUE0QztFQUM1Qyw0Q0FBNEM7RUFDNUMsNENBQTRDO0FBQzlDOztBQUVBO0VBQ0UsK0NBQStDO0VBQy9DLCtDQUErQztFQUMvQywrQ0FBK0M7QUFDakQiLCJmaWxlIjoic3JjL2FwcC9hcHAuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5yb2xlLXNlbGVjdG9yIGlucHV0IHtcclxuICBtYXJnaW46IDA7XHJcbiAgcGFkZGluZzogMDtcclxuICAtd2Via2l0LWFwcGVhcmFuY2U6IG5vbmU7XHJcbiAgLW1vei1hcHBlYXJhbmNlOiBub25lO1xyXG4gIC8qYXBwZWFyYW5jZTogbm9uZTsqL1xyXG59XHJcblxyXG4udyAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy93LnBuZ1wiKTsgfVxyXG4uZCAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9kLnBuZ1wiKTsgfVxyXG4uYSAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9hLnBuZ1wiKTsgfVxyXG4ucCAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9wLnBuZ1wiKTsgfVxyXG4uciAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9yLnBuZ1wiKTsgfVxyXG4uZSAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9lLnBuZ1wiKTsgfVxyXG4ubiAgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9uLnBuZ1wiKTsgfVxyXG4ubWUgICB7IGJhY2tncm91bmQtaW1hZ2U6IHVybChcIi4uL2Fzc2V0cy9tZS5wbmdcIik7IH1cclxuLnByb3QgeyBiYWNrZ3JvdW5kLWltYWdlOiB1cmwoXCIuLi9hc3NldHMvcHJvdC5wbmdcIik7IH1cclxuLmhlYWwgeyBiYWNrZ3JvdW5kLWltYWdlOiB1cmwoXCIuLi9hc3NldHMvaGVhbC5wbmdcIik7IH1cclxuLnJ0ICAgeyBiYWNrZ3JvdW5kLWltYWdlOiB1cmwoXCIuLi9hc3NldHMvcnQucG5nXCIpOyB9XHJcblxyXG4ucm9sZS1zZWxlY3RvciBpbnB1dDphY3RpdmUgKyAucm9sZSB7XHJcbiAgb3BhY2l0eTogLjk7XHJcbn1cclxuXHJcbi5yb2xlLXNlbGVjdG9yIGlucHV0OmNoZWNrZWQgKyAucm9sZSB7XHJcbiAgLXdlYmtpdC1maWx0ZXI6IG5vbmU7XHJcbiAgLW1vei1maWx0ZXI6IG5vbmU7XHJcbiAgZmlsdGVyOiBub25lO1xyXG59XHJcblxyXG4ucm9sZSB7XHJcbiAgY3Vyc29yOiBwb2ludGVyO1xyXG4gIGJhY2tncm91bmQtc2l6ZTogY29udGFpbjtcclxuICBiYWNrZ3JvdW5kLXJlcGVhdDogbm8tcmVwZWF0O1xyXG4gIGRpc3BsYXk6IGlubGluZS1ibG9jaztcclxuICB3aWR0aDogMjBweDtcclxuICBoZWlnaHQ6IDIwcHg7XHJcbiAgLyotd2Via2l0LXRyYW5zaXRpb246IGFsbCAxMDBtcyBlYXNlLWluO1xyXG4gIC1tb3otdHJhbnNpdGlvbjogYWxsIDEwMG1zIGVhc2UtaW47XHJcbiAgdHJhbnNpdGlvbjogYWxsIDEwMG1zIGVhc2UtaW47Ki9cclxuICAtd2Via2l0LWZpbHRlcjogYnJpZ2h0bmVzcygwLjUpIGdyYXlzY2FsZSgxKTtcclxuICAtbW96LWZpbHRlcjogICAgYnJpZ2h0bmVzcygwLjUpIGdyYXlzY2FsZSgxKTtcclxuICBmaWx0ZXI6ICAgICAgICAgYnJpZ2h0bmVzcygwLjUpIGdyYXlzY2FsZSgxKTtcclxufVxyXG5cclxuLnJvbGU6aG92ZXIge1xyXG4gIC13ZWJraXQtZmlsdGVyOiBicmlnaHRuZXNzKDEuNTApIGdyYXlzY2FsZSgwLjUpO1xyXG4gIC1tb3otZmlsdGVyOiAgICBicmlnaHRuZXNzKDEuNTApIGdyYXlzY2FsZSgwLjUpO1xyXG4gIGZpbHRlcjogICAgICAgICBicmlnaHRuZXNzKDEuNTApIGdyYXlzY2FsZSgwLjUpO1xyXG59XHJcbiJdfQ== */");

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");


let AppComponent = class AppComponent {
    constructor() {
        this.lobby = [];
        this.team1 = [];
        this.team2 = [];
        this.history = [];
        this.enum_roles = ['w', 'd', 'a', 'p', 'r', 'e', 'n', 'me', 'prot', 'heal', 'rt'];
    }
    ngOnInit() {
        //this.setLobbyPlayerNumbers();
        var count = 1;
        //this.addToLobby({ name: 'Holye',     pos: count++, role: null, pref: ['w', 'd', 'a', 'p', 'r', 'e', 'n', 'me', 'prot', 'heal', 'rt'] });
        //this.addToLobby({ name: 'Yoko',     pos: count++, role: null, pref: ['w', 'd', 'p', 'e', 'n', 'me'] });
        //this.addToLobby({ name: 'Candyboy', pos: count++, role: null, pref: ['w', 'me'] });
        //this.addToLobby({ name: 'Godly',    pos: count++, role: null, pref: ['a'] });
        //this.addToLobby({ name: 'Santana',  pos: count++, role: null, pref: ['heal'] });
        //this.addToLobby({ name: 'Purif',    pos: count++, role: null, pref: ['me', 'prot', 'heal'] });
        //this.addToLobby({ name: 'Chrona',   pos: count++, role: null, pref: ['w', 'r', 'e', 'me'] });
        //this.addToLobby({ name: 'Butters',  pos: count++, role: null, pref: ['w', 'd', 'e'] });
        //this.addToLobby({ name: 'Ice',      pos: count++, role: null, pref: ['w', 'heal'] });
        //this.addToLobby({ name: 'Lisek',    pos: count++, role: null, pref: ['r', 'me'] });
        //this.addToLobby({ name: 'Oln',      pos: count++, role: null, pref: ['heal'] });
        //this.addToLobby({ name: 'Rainy',    pos: count++, role: null, pref: ['prot'] });
        //this.addToLobby({ name: 'Takida',   pos: count++, role: null, pref: ['w'] });
        //this.addToLobby({ name: 'Jo',       pos: count++, role: null, pref: ['e'] });
        //this.addToLobby({ name: 'Bounty',   pos: count++, role: null, pref: ['w', 'p', 'me'] });
        //this.addToLobby({ name: 'Cracks',   pos: count++, role: null, pref: ['w'] });
        //this.addToLobby({ name: 'Beware',   pos: count++, role: null, pref: ['prot'] });
        //this.addToLobby({ name: 'Jonas',    pos: count++, role: null, pref: ['w', 'prot'] });
        //this.addToLobby({ name: 'Dopos',    pos: count++, role: null, pref: ['r', 'me'] });
        //this.addToLobby({ name: 'Hemo',     pos: count++, role: null, pref: ['w', 'd'] });
        this.addToLobby({ name: 'Slam', pos: count++, role: null, pref: ['w'] });
        this.addToLobby({ name: 'Candy', pos: count++, role: null, pref: ['w', 'me'] });
        this.addToLobby({ name: 'Yoko', pos: count++, role: null, pref: ['w', 'd', 'p', 'e', 'me'] });
        this.addToLobby({ name: 'Takida', pos: count++, role: null, pref: ['w'] });
        this.addToLobby({ name: 'Bounty', pos: count++, role: null, pref: ['w', 'p', 'me', 'prot'] });
        this.addToLobby({ name: 'Godly', pos: count++, role: null, pref: ['me'] });
        this.addToLobby({ name: 'Hemo', pos: count++, role: null, pref: ['w', 'd', 'me'] });
        this.addToLobby({ name: 'Martin', pos: count++, role: null, pref: ['heal', 'prot'] });
        this.addToLobby({ name: 'Dopos', pos: count++, role: null, pref: ['r', 'me'] });
        this.addToLobby({ name: 'Rainy', pos: count++, role: null, pref: ['prot'] });
        this.addToLobby({ name: 'Holye', pos: count++, role: null, pref: ['d', 'e', 'heal'] });
        this.addToLobby({ name: 'Yoshi', pos: count++, role: null, pref: ['prot'] });
        this.addToLobby({ name: 'Oln', pos: count++, role: null, pref: ['heal'] });
        this.addToLobby({ name: 'Santana', pos: count++, role: null, pref: ['heal'] });
        this.addToLobby({ name: 'Beware', pos: count++, role: null, pref: ['prot'] });
        this.addToLobby({ name: 'Purif', pos: count++, role: null, pref: ['me', 'prot', 'heal'] });
        this.addToLobby({ name: 'Ice', pos: count++, role: null, pref: ['w', 'heal'] });
        this.addToLobby({ name: 'Cracks', pos: count++, role: null, pref: ['w'] });
        this.addToLobby({ name: 'Butters', pos: count++, role: null, pref: ['w', 'd', 'e', 'me'] });
        this.addToLobby({ name: 'Roken', pos: count++, role: null, pref: ['w'] });
    }
    // UTILITY
    removeFromList(player, list) {
        var index = list.indexOf(player);
        list.splice(index, 1);
    }
    // PAGE FUNCTIONS
    setRole(player, role, team) {
        console.log('player: ' + player.name + ', team: ' + team);
        if (team == 1) {
            var index = this.team1.indexOf(player);
            this.team1[index].role = role;
        }
        else if (team == 2) {
            var index = this.team2.indexOf(player);
            this.team2[index].role = role;
        }
    }
    sortLobby() {
        this.lobby.sort((a, b) => a.pos - b.pos);
    }
    //setLobbyPlayerNumbers(): void {
    //  for (var i = 0; i < this.lobby.length; i++)
    //    this.lobby[i].pos = i + 1;
    //}
    addMessage(msg) {
        if (this.history.length >= 22)
            this.history.pop();
        this.history.unshift('[' + new Date().toLocaleTimeString() + '] ' + msg);
    }
    addToLobby(player) {
        player.pos = this.lobby.length + 1;
        this.lobby.push(player);
        this.addMessage(player.name + ' joined.');
    }
    removeFromLobby(player) {
        this.removeFromList(player, this.lobby);
        //this.setLobbyPlayerNumbers();
        this.addMessage('You kicked ' + player.name + '.');
    }
    lobbyToTeam1(player) {
        if (this.team1.length == 8)
            return;
        this.removeFromList(player, this.lobby);
        this.team1.push(player);
        this.addMessage('You added ' + player.name + ' to Team 1.');
    }
    lobbyToTeam2(player) {
        if (this.team2.length == 8)
            return;
        this.removeFromList(player, this.lobby);
        this.team2.push(player);
        this.addMessage('You added ' + player.name + ' to Team 2.');
    }
    team1ToLobby(player) {
        this.removeFromList(player, this.team1);
        this.lobby.push(player);
        this.sortLobby();
        this.addMessage('You removed ' + player.name + ' from Team 1.');
    }
    team2ToLobby(player) {
        this.removeFromList(player, this.team2);
        this.lobby.push(player);
        this.sortLobby();
        this.addMessage('You removed ' + player.name + ' from Team 2.');
    }
    team1ToTeam2(player) {
        if (this.team2.length == 8)
            return;
        this.removeFromList(player, this.team1);
        this.team2.push(player);
        this.addMessage('You moved ' + player.name + ' to Team 2.');
    }
    team2ToTeam1(player) {
        if (this.team1.length == 8)
            return;
        this.removeFromList(player, this.team2);
        this.team1.push(player);
        this.addMessage('You moved ' + player.name + ' to Team 1.');
    }
    team1Clear() {
        if (this.team1.length == 0)
            return;
        this.lobby = this.lobby.concat(this.team1);
        this.sortLobby();
        this.team1 = [];
        this.addMessage('You cleared Team 1.');
    }
    team2Clear() {
        if (this.team2.length == 0)
            return;
        this.lobby = this.lobby.concat(this.team2);
        this.sortLobby();
        this.team2 = [];
        this.addMessage('You cleared Team 2.');
    }
    team1Win() {
        if (this.team1.length == 8 && this.team2.length == 8)
            this.addMessage('You recorded a win for Team 1.');
    }
    team2Win() {
        if (this.team1.length == 8 && this.team2.length == 8)
            this.addMessage('You recorded a win for Team 2.');
    }
};
AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
        selector: 'app-root',
        template: tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(/*! raw-loader!./app.component.html */ "./node_modules/raw-loader/dist/cjs.js!./src/app/app.component.html")).default,
        styles: [tslib__WEBPACK_IMPORTED_MODULE_0__["__importDefault"](__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")).default]
    })
], AppComponent);



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");





let AppModule = class AppModule {
};
AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
        declarations: [
            _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]
        ],
        imports: [
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
            _app_routing_module__WEBPACK_IMPORTED_MODULE_3__["AppRoutingModule"]
        ],
        providers: [],
        bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
    })
], AppModule);



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

const environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm2015/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");





if (_environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_2__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_3__["AppModule"])
    .catch(err => console.error(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Users\nikit\source\repos\Projects\QQbot\WebClient\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main-es2015.js.map