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
var PADDING = {
    RIGHT: 'padding-right',
    LEFT: 'padding-left',
    TOP: 'padding-top',
    BOTTOM: 'padding-bottom',
};
var MARGIN = {
    RIGHT: 'margin-right',
    LEFT: 'margin-left',
    TOP: 'margin-top',
    BOTTOM: 'margin-bottom',
};
var getStyle = function (el, str) {
    return parseInt(getComputedStyle(el).getPropertyValue(str), 10);
};
var getTextNodeBoundingClientRect = function (list) {
    var node = (list.length ? list[list.length - 1] : list);
    if (document.createRange) {
        var range = document.createRange();
        if (range.getBoundingClientRect) {
            range.selectNodeContents(node);
            return range.getBoundingClientRect();
        }
    }
};
var getDimension = function (node) {
    var margin = {}, padding = {
        right: getStyle(node, PADDING.RIGHT),
        left: getStyle(node, PADDING.LEFT),
        top: getStyle(node, PADDING.TOP),
        bottom: getStyle(node, PADDING.BOTTOM),
    };
    if (node.childElementCount) {
        var child = node.childNodes[0];
        margin.height = getStyle(child, MARGIN.BOTTOM) + getStyle(child, MARGIN.TOP);
        margin.width = getStyle(child, MARGIN.LEFT) + getStyle(child, MARGIN.RIGHT);
        return {
            width: (child.scrollWidth || child.offsetWidth) + margin.width + padding.left + padding.right,
            height: (child.scrollHeight || child.offsetHeight) + margin.height + padding.top + padding.bottom,
        };
    }
    var range = getTextNodeBoundingClientRect(node.childNodes);
    return {
        width: range.width + padding.right + padding.left,
        height: range.height + padding.bottom + padding.top
    };
};
var Toggle = /** @class */ (function (_super) {
    __extends(Toggle, _super);
    function Toggle(props) {
        var _this = _super.call(this, props) || this;
        _this.state = { width: null, height: null };
        return _this;
    }
    Toggle.prototype.onClick = function () {
        if (this.props.disabled)
            return;
        this.props.onChange && this.props.onChange(!this.state.active);
        this.setState({ active: !this.state.active });
    };
    Toggle.prototype.setDimensions = function (props) {
        var onDim = getDimension(this.refs.on);
        var offDim = getDimension(this.refs.off);
        var width = Math.max(onDim.width, offDim.width);
        var height = Math.max(onDim.height, offDim.height);
        var active = props.active !== undefined ? props.active : this.state.active;
        this.setState({
            width: props.width || width,
            height: props.height || height,
            active: active
        });
    };
    Toggle.prototype.componentDidMount = function () {
        this.setDimensions(this.props);
    };
    Toggle.prototype.componentWillReceiveProps = function (props) {
        this.setDimensions(props);
    };
    Toggle.prototype.getSizeClass = function () {
        if (this.props.size === 'large')
            return 'btn-lg';
        if (this.props.size === 'small')
            return 'btn-sm';
        if (this.props.size === 'mini')
            return 'btn-xs';
        return '';
    };
    Toggle.prototype.render = function () {
        var onstyle = "btn-" + this.props.onstyle;
        var offstyle = 'btn-' + this.props.offstyle;
        var toggleOn = 'toggle-on';
        var toggleOff = 'toggle-off';
        var sizeClass = this.getSizeClass();
        var activeClass = "btn toggle " + sizeClass + " " + onstyle;
        var inactiveClass = "btn toggle " + sizeClass + " " + offstyle + " off";
        var onStyleClass = "btn " + toggleOn + " " + sizeClass + " " + onstyle;
        var offStyleClass = "btn " + toggleOff + " " + sizeClass + " " + offstyle;
        var style = {
            width: this.state.width,
            height: this.state.height
        };
        return (React.createElement("div", { ref: 'switcher', className: this.state.active ? activeClass : inactiveClass, onClick: this.onClick.bind(this), style: style },
            React.createElement("div", { className: "toggle-group" },
                React.createElement("label", { ref: 'on', className: onStyleClass }, this.props.on),
                React.createElement("label", { ref: 'off', className: offStyleClass }, this.props.off),
                React.createElement("span", { ref: 'toggle', className: "toggle-handle btn btn-default" }))));
    };
    Toggle.defaultProps = {
        onstyle: 'primary',
        offstyle: 'default',
        width: '',
        height: '',
        on: 'On',
        off: 'Off',
        disabled: false,
        size: 'normal',
        active: true
    };
    return Toggle;
}(React.Component));
exports.Toggle = Toggle;
//# sourceMappingURL=Toggle.js.map