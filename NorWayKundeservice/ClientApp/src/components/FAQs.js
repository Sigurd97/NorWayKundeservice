import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Spinner, Breadcrumb } from 'reactstrap';
import { SubKategoriCollapseItem } from './SubKategoriCollapseItem'

export class FAQs extends Component {
    static displayName = FAQs.name;

    constructor(props) {
        super(props);
        this.state = { SubKategorier: [], loadingSubKategorier: true, loadingMainKategori: true };
    }

    componentDidMount() {   
        const { match: { params } } = this.props;
        this.getSubKategorier(params.MainKategoriId);
        this.getMainKategori(params.MainKategoriId);
    }

    render() {
        let SubKategorier = this.state.loadingSubKategorier
            ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
            : FAQs.renderSubKategoriList(this.state.SubKategorier);
        let MainKategori = this.state.loadingMainKategori
            ? <p></p>
            : this.state.MainKategoriNavn;
        return (
            <div>
                <Breadcrumb tag="nav" listTag="div">
                    <Link className="breadcrumb-item" to={'/'}>Hjem</Link>
                    <div className="active breadcrumb-item">{MainKategori}</div>
                </Breadcrumb>
                <h1>FAQ</h1>
                <br></br><hr></hr>
                {SubKategorier}
            </div>
        );
    }

    static renderSubKategoriList(SubKategorier) {
        return (
            <div>
                {SubKategorier.map(SubKategori =>
                    <SubKategoriCollapseItem key={SubKategori.id} SubKategori={SubKategori} />
                )}
            </div>
        );
    }

    async getSubKategorier(MainKategoriId) {
        const response = await fetch('api/kundeservice/SubKategorier?MainKategoriId=' + MainKategoriId);
        const data = await response.json();
        this.setState({ subKategorier: data, loadingSubKategorier: false });
    }

    async getMainKategori(MainKategoriId) {
        const response = await fetch('api/kundeservice/MainKategori?MainKategoriId=' + MainKategoriId);
        const data = await response.json();
        console.dir(data);
        this.setState({ MainKategoriNavn: data, loadingMainKategori: false });
    }
}