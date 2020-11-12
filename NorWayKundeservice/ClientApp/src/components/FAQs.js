import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Spinner, Breadcrumb } from 'reactstrap';
import { UnderkategoriCollapseItem } from './UnderkategoriCollapseItem';

export class FAQs extends Component {
    static displayName = FAQs.name;

    constructor(props) {
        super(props);
        this.state = { underkategorier: [], loadingUnderkategorier: true, loadingHovedkategori: true };
    }

    componentDidMount() {   
        const { match: { params } } = this.props;
        this.getUnderkategorier(params.hovedkategoriId);
        this.getHovedkategori(params.hovedkategoriId);
    }

    render() {
        let underkategorier = this.state.loadingUnderkategorier
            ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
            : FAQs.renderUnderkategoriList(this.state.underkategorier);
        let hovedkategori = this.state.loadingHovedkategori
            ? <p></p>
            : this.state.hovedkategoriNavn;
        return (
            <div>
                <Breadcrumb tag="nav" listTag="div">
                    <Link className="breadcrumb-item" to={'/'}>Hjem</Link>
                    <div className="active breadcrumb-item">{hovedkategori}</div>
                </Breadcrumb>
                <h1>Spørsmål og svar</h1>
                <br></br><hr></hr>
                {underkategorier}
            </div>
        );
    }

    static renderUnderkategoriList(underkategorier) {
        return (
            <div>
                {underkategorier.map(underkategori =>
                    <UnderkategoriCollapseItem key={underkategori.id} underkategori={underkategori} />
                )}
            </div>
        );
    }

    async getUnderkategorier(hovedkategoriId) {
        const response = await fetch('api/kundeservice/underkategorier?hovedkategoriId=' + hovedkategoriId);
        const data = await response.json();
        this.setState({ underkategorier: data, loadingUnderkategorier: false });
    }

    async getHovedkategori(hovedkategoriId) {
        const response = await fetch('api/kundeservice/hovedkategori?hovedkategoriId=' + hovedkategoriId);
        const data = await response.json();
        console.dir(data);
        this.setState({ hovedkategoriNavn: data, loadingHovedkategori: false });
    }
}