import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Jumbotron, Spinner } from 'reactstrap'

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { MainKategorier: [], loading: true };
    }

    componentDidMount() {
        this.getMainKategorier();
    }

    static renderMainKategoriList(MainKategorier) {
        return (
            <div>
                {MainKategorier.map(kategori =>
                    <Jumbotron key={kategori.id}>
                       <h2> <Link className="text-dark" to={`/faqs/${kategori.id}`}>{kategori.navn}</Link> </h2>
                    </Jumbotron>
                )}
            </div>
        );
    }

    render() {
        let MainKategorier = this.state.loading
            ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
            : Home.renderMainKategoriList(this.state.MainKategorier);

        return (
            <div>
                <h1>FAQ</h1><br></br>
                <h5>Hva lurer du på?</h5><br></br><hr></hr>
                {MainKategorier}
            </div>
        );
    }

    async getMainKategorier() {
        const response = await fetch('api/kundeservice/MainKategorier');
        const data = await response.json();
        this.setState({ MainKategorier: data, loading: false });

    }
}