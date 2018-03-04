"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = y[op[0] & 2 ? "return" : op[0] ? "throw" : "next"]) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [0, t.value];
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
};
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var ReactDOM = require("react-dom");
var components_1 = require("components");
var react_bootstrap_1 = require("react-bootstrap");
var services_1 = require("services");
var Golfers = /** @class */ (function (_super) {
    __extends(Golfers, _super);
    function Golfers(props) {
        var _this = _super.call(this, props) || this;
        _this.state = {
            golfers: _this.props.golfers
        };
        return _this;
    }
    Golfers.prototype.componentDidMount = function () {
        return __awaiter(this, void 0, void 0, function () {
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, services_1.api.getAllGolfers()
                            .then(function (data) { _this.setState({ golfers: data }); })];
                    case 1:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    Golfers.prototype.setGolferActiveFlag = function (golfer, value) {
        golfer.isActive = value;
        services_1.api.setGolferActiveFlag({ id: golfer.id, value: value }, golfer.lastName);
    };
    Golfers.prototype.render = function () {
        var _this = this;
        var state = this.state;
        return (React.createElement(react_bootstrap_1.Table, { hover: true, condensed: true },
            React.createElement("thead", null,
                React.createElement("tr", null,
                    React.createElement("th", null, "Member #"),
                    React.createElement("th", null, "Name"),
                    React.createElement("th", null, "Handicap"),
                    React.createElement("th", null, "Active*"),
                    React.createElement("th", null, "Actions"))),
            React.createElement("tbody", null, state.golfers.map(function (g) { return (React.createElement("tr", { key: g.id },
                React.createElement("td", null, g.membershipId),
                React.createElement("td", null,
                    g.firstName,
                    " ",
                    g.lastName),
                React.createElement("td", null, g.handicap),
                React.createElement("td", null,
                    React.createElement(components_1.Toggle, { offstyle: "danger", active: g.isActive, onChange: function (v) { return _this.setGolferActiveFlag(g, v); } })),
                React.createElement("td", null,
                    React.createElement(react_bootstrap_1.Button, { href: "Edit" }, "Edit"),
                    React.createElement(react_bootstrap_1.Button, null, "Delete")))); }))));
    };
    return Golfers;
}(React.Component));
ReactDOM.render(React.createElement(Golfers, { golfers: [] }), document.getElementById("react-golfer-list"));
//# sourceMappingURL=List.main.js.map