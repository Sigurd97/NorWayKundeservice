import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FAQs } from './components/FAQs';
import { FAQForm } from './components/FAQForm';
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/faqs/:hovedkategoriId' component={FAQs} />
        <Route path='/skjema' component={FAQForm} />
      </Layout>
    );
  }
}