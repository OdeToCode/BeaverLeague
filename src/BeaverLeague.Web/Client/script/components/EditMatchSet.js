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
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_bootstrap_1 = require("react-bootstrap");
var models_1 = require("models");
var GolferList = function (props) {
    return React.createElement(react_bootstrap_1.Panel, { Header: React.createElement("h3", null, props.name), bsStyle: "primary", className: "nogutter" },
        React.createElement(react_bootstrap_1.Table, { condensed: true, hover: true },
            React.createElement("tbody", null, props.golfers.map(function (g) {
                return React.createElement("tr", { key: g.id, onClick: function () { return props.selectGolfer(g); } },
                    React.createElement("td", null,
                        React.createElement("span", { className: "pull-right" }, g.isSelected ? React.createElement("a", { href: "#", title: "Selected" },
                            React.createElement("i", { className: "fa fa-check" })) :
                            React.createElement("a", { href: "#", title: "Inactive" },
                                React.createElement("i", { className: "fa fa-bed" }))),
                        g.firstName,
                        " ",
                        g.lastName));
            }))));
};
var InactiveList = function (props) {
    return React.createElement(react_bootstrap_1.Panel, { header: React.createElement("h3", null, "Inactive This Week"), bsStyle: "primary", className: "nogutter" },
        React.createElement(react_bootstrap_1.Table, { hover: true },
            React.createElement("tbody", null, props.inactives.map(function (i) {
                return React.createElement("tr", { key: i.id },
                    React.createElement("td", null,
                        i.firstName,
                        " ",
                        i.lastName));
            }))));
};
var MatchList = function (props) {
    return React.createElement(react_bootstrap_1.Panel, { header: React.createElement("h3", null, "Matchups"), bsStyle: "primary", className: "nogutter" },
        React.createElement(react_bootstrap_1.Table, { hover: true },
            React.createElement("tbody", null, props.matches.map(function (m) {
                return React.createElement("tr", { key: m.id },
                    React.createElement("td", null,
                        React.createElement("span", { className: "pull-right" },
                            React.createElement("a", { href: "#", title: "Remove match", onClick: function () { return props.deleteMatch(m); } },
                                React.createElement("i", { className: "fa fa-remove" }))),
                        React.createElement("div", null,
                            m.golferA.firstName[0],
                            " ",
                            m.golferA.lastName,
                            "\u00A0v\u00A0",
                            m.golferB.firstName[0],
                            " ",
                            m.golferB.lastName)));
            }))));
};
var EditMatchSet = /** @class */ (function (_super) {
    __extends(EditMatchSet, _super);
    function EditMatchSet(props) {
        var _this = _super.call(this, props) || this;
        _this.store = new models_1.EditMatchSetStore(_this);
        _this.state = _this.store.produceState();
        return _this;
    }
    EditMatchSet.prototype.componentDidMount = function () {
        this.store.load(this.props.matchSetId);
    };
    EditMatchSet.prototype.render = function () {
        var store = this.store, state = this.state;
        return (React.createElement(react_bootstrap_1.Grid, { fluid: true },
            React.createElement(react_bootstrap_1.Row, null,
                React.createElement(react_bootstrap_1.Col, { sm: 12 },
                    React.createElement("h3", { className: "text-center" },
                        "Week # ",
                        state.matchset.matchSetNumber))),
            React.createElement(react_bootstrap_1.Row, null,
                React.createElement(react_bootstrap_1.Col, { sm: 4 },
                    React.createElement(GolferList, { name: "Golfers", golfers: state.golfers, selectGolfer: function (g) { return store.selectGolfer(g); } })),
                React.createElement(react_bootstrap_1.Col, { sm: 4 }),
                React.createElement(react_bootstrap_1.Col, { sm: 4 },
                    React.createElement(InactiveList, { inactives: state.inactives }))),
            React.createElement(react_bootstrap_1.Row, null,
                React.createElement(react_bootstrap_1.Button, { bsStyle: "primary" }, "Run AutoMatcher!"))));
    };
    return EditMatchSet;
}(React.Component));
exports.EditMatchSet = EditMatchSet;
//# sourceMappingURL=EditMatchSet.js.map