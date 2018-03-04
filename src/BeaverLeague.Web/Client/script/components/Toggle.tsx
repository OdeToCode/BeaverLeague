import * as React from 'react';

const PADDING = {
  RIGHT   : 'padding-right',
  LEFT    : 'padding-left',
  TOP     : 'padding-top',
  BOTTOM  : 'padding-bottom',
};

const MARGIN = {
  RIGHT   : 'margin-right',
  LEFT    : 'margin-left',
  TOP     : 'margin-top',
  BOTTOM  : 'margin-bottom',
};

const getStyle = (el: Element, str: string) => {
  return parseInt(getComputedStyle(el).getPropertyValue(str), 10);
}

const getTextNodeBoundingClientRect = (list: NodeList) : ClientRect => {
  const node = (list.length ? list[list.length - 1] : list) as Node;
  if (document.createRange) {
    let range = document.createRange();
    if (range.getBoundingClientRect) {
      range.selectNodeContents(node);
      return range.getBoundingClientRect();
    }
  }
}

interface MarginShape {
  height?: number
  width?: number
}

const getDimension = (node: HTMLElement) => {
  let margin: MarginShape = {},
      padding = {
        right   : getStyle(node, PADDING.RIGHT),
        left    : getStyle(node, PADDING.LEFT),
        top     : getStyle(node, PADDING.TOP),
        bottom  : getStyle(node, PADDING.BOTTOM),
      };

  if (node.childElementCount) {
    let child       = node.childNodes[0] as HTMLElement;
    margin.height   = getStyle(child, MARGIN.BOTTOM) +  getStyle(child, MARGIN.TOP);
    margin.width    = getStyle(child, MARGIN.LEFT) +  getStyle(child, MARGIN.RIGHT);

    return {
      width : (child.scrollWidth || child.offsetWidth) + margin.width + padding.left + padding.right,
      height : (child.scrollHeight || child.offsetHeight) + margin.height + padding.top + padding.bottom,
    }
  }

  let range = getTextNodeBoundingClientRect(node.childNodes);

  return {
    width : range.width + padding.right + padding.left,
    height : range.height + padding.bottom + padding.top
  }
}

interface ToggleProps{
  onstyle?: string,
  offstyle?: string, 
  height?: number,
  width?: number,
  on?: React.ReactNode,
  off?: React.ReactNode,
  active?: boolean,
  disabled?: boolean,
  size?: string,
  onChange?: (active: boolean) => void
}

interface ToggleState {
  width?: number,
  height?: number,
  active?: boolean,
}
  
export class Toggle extends React.Component<ToggleProps, ToggleState> {
  constructor(props : ToggleProps) {
    super(props);
    this.state = {width: null, height: null};
  }

  onClick() {
    if (this.props.disabled) return;
    this.props.onChange && this.props.onChange(!this.state.active);
    this.setState({active : !this.state.active});
  }

  setDimensions(props: ToggleProps) {
    const onDim   = getDimension(this.refs.on);
    const offDim  = getDimension(this.refs.off);

    const width   = Math.max(onDim.width, offDim.width);
    const height  = Math.max(onDim.height, offDim.height);
    const active = props.active !== undefined? props.active : this.state.active;
            
    this.setState({
      width: props.width || width,
      height: props.height || height,
      active
    });
  }

  componentDidMount() {
    this.setDimensions(this.props);
  }

  componentWillReceiveProps(props: ToggleProps) {
    this.setDimensions(props);
  }


  getSizeClass() {
    if (this.props.size === 'large') return 'btn-lg';
    if (this.props.size === 'small') return 'btn-sm';
    if (this.props.size === 'mini')  return 'btn-xs';
    return '';
  }

  static defaultProps = {
    onstyle     : 'primary',
    offstyle    : 'default',
    width       : '',
    height      : '',
    on          : 'On',
    off         : 'Off',
    disabled    : false,
    size        : 'normal',
    active      : true
  };

  refs: {      
      on:HTMLElement;
      off: HTMLElement;
  }

  render() {
    const onstyle = `btn-${this.props.onstyle}`;
    const offstyle = 'btn-' + this.props.offstyle;
    const toggleOn = 'toggle-on';
    const toggleOff = 'toggle-off';
    const sizeClass = this.getSizeClass();
    const activeClass = `btn toggle ${sizeClass} ${onstyle}`;
    const inactiveClass = `btn toggle ${sizeClass} ${offstyle} off`;
    const onStyleClass = `btn ${toggleOn} ${sizeClass} ${onstyle}`;
    const offStyleClass = `btn ${toggleOff} ${sizeClass} ${offstyle}`;

    const style = {
      width  : this.state.width,
      height : this.state.height
    };

    return (
      <div
        ref='switcher'            
        className={this.state.active ? activeClass : inactiveClass}
        onClick={this.onClick.bind(this)}
        style={style}>
        <div className="toggle-group">
          <label ref='on'  className={onStyleClass}>{this.props.on}</label>
          <label ref='off'  className={offStyleClass}>{this.props.off}</label>
          <span  ref='toggle' className="toggle-handle btn btn-default"></span>
        </div>
      </div>
    );
  }
}