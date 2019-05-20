import React, { Component } from 'react';
import RuleManageTable from './components/RuleManageTable';

export default class RuleManage extends Component {
  static displayName = 'RuleManage';

  static propTypes = {};

  static defaultProps = {};

  constructor(props) {
    super(props);
    this.state = {};
  }

  render() {
    return (
      <div>
        <RuleManageTable />
      </div>
    );
  }
}
