"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var components_1 = require("components");
var services_1 = require("services");
var ReactDOM = require("react-dom");
var React = require("react");
var elementName = "react-creatematchset";
var element = document.getElementById(elementName);
var props = services_1.parameters(element);
ReactDOM.render(React.createElement(components_1.EditMatchSet, { matchSetId: props.matchSetId }), element);
//# sourceMappingURL=edit.main.js.map