/* eslint react/no-string-refs:0 */
import React, { Component } from 'react';
import { Button, Select, Input, Message } from '@alifd/next';
import { FormBinderWrapper, FormBinder } from '@icedesign/form-binder';

export default class TableFilter extends Component {
  state = {
    value: {},
  };

  handleSubmit = () => {
    const { validateFields } = this.refs.form;
    validateFields((errors, values) => {
      if (errors) {
        Message.error('查询参数错误');
        return;
      }
      this.props.handleSubmit(values);
    });
  };

  render() {
    return (
      <FormBinderWrapper value={this.state.value} ref="form">
        <div style={styles.tableFilter}>
          <div style={styles.filterItem}>
            <span style={styles.filterLabel}>规则名称：</span>
            <FormBinder name="ruleName">
              <Input placeholder="请输入规则名称" />
            </FormBinder>
          </div>

          <div style={styles.filterItem}>
            <span style={styles.filterLabel}>规则类型：</span>
            <FormBinder name="ruleType">
              <Select>
                <Select.Option value="travis">Travis CI</Select.Option>
                <Select.Option value="jenkins">Jenkins</Select.Option>
              </Select>
            </FormBinder>
          </div>

          <div style={styles.filterItem}>
            <span style={styles.filterLabel}>状态：</span>
            <FormBinder name="status">
              <Select>
                <Select.Option value="all">全部</Select.Option>
                <Select.Option value="enable">启用</Select.Option>
                <Select.Option value="disable">禁用</Select.Option>
              </Select>
            </FormBinder>
          </div>
          <Button
            type="primary"
            style={styles.submitButton}
            onClick={this.handleSubmit}
          >
            查询
          </Button>
        </div>
      </FormBinderWrapper>
    );
  }
}

const styles = {
  tableFilter: {
    display: 'flex',
    background: '#f4f4f4',
    padding: '15px 0',
    marginBottom: '20px',
  },
  filterItem: {
    display: 'flex',
    alignItems: 'center',
    marginLeft: '15px',
  },
  submitButton: {
    marginLeft: '15px',
  },
};
