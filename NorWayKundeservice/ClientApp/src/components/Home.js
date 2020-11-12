import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Jumbotron, Spinner } from 'reactstrap'

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { hovedkategorier: [], loading: true };
    }

    componentDidMount() {
        this.getHovedkategorier();
    }

    static renderHovedkategoriList(hovedkategorier) {
        return (
            <div>
                {hovedkategorier.map(kategori =>
                    <Jumbotron key={kategori.id}>
                       <h2> <Link className="text-dark" to={`/faqs/${kategori.id}`}>{kategori.navn}</Link> </h2>
                    </Jumbotron>
                )}
            </div>
        );
    }

    render() {
        let hovedkategorier = this.state.loading
            ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
            : Home.renderHovedkategoriList(this.state.hovedkategorier);

        return (
            <div>
                <h1>Spørsmål og svar</h1><br></br>
                <h5>Hva lurer du på? Velg tema og finn svar på alt fra hvem som<br></br>
                    kan få rabatt og hvordan du søker om refusjon til hvordan<br></br>
                    appen fungerer og hva slags bagasje du kan ha med om bord.</h5><br></br><hr></hr>
                {hovedkategorier}
            </div>
        );
    }

    async getHovedkategorier() {
        const response = await fetch('api/kundeservice/hovedkategorier');
        const data = await response.json();
        this.setState({ hovedkategorier: data, loading: false });
    }
}