import React from 'react';
import { Link } from 'react-router-dom';
import { AvForm, AvField } from 'availity-reactstrap-validation';
import { Button, FormGroup, Spinner, Breadcrumb, Alert } from 'reactstrap';

export class FAQForm extends React.Component {

    static displayName = FAQForm.name;

    constructor() {
        super();
        this.state = {
            MainKategorier: [],
            SubKategorier: [],
            loadingMainKategorier: true,
            loadingSubKategorier: true,
            MainKategoriId: 1,
            SubKategoriId: 1,
            errorOnSend: false,
            errorMessage: "",
            sendComplete: false
        };
    }

    componentDidMount() {
        this.populateMainKategorier();
    }

    async changeMainkategori(event) {
        this.setState({ hovedkategoriId: event.target.value });
        event.persist();

        await this.populateMainkategorier(event.target.value);
    }

    async changeSubKategori(event) {
        this.setState({ SubKategoriId: event.target.value });
    }

    async populateMainKategorier() {
        const response = await fetch('api/kundeservice/MainKategorier');
        const data = await response.json();
        this.setState({ MainKategorier: data, loadingMainKategorier: false });
        await this.populateSubKategorier(1);
    }

    async populateSubKategorier(SubKategoriId) {
        const response = await fetch('api/kundeservice/underkategorier?hovedkategoriId=' + SubKategoriId);
        const data = await response.json();
        this.setState({ SubKategoriId: SubKategoriId, SubKategorier: data, loadingSubKategorier: false });
    }

    onValidSubmit = (event, values) => {
        this.setState({ errorOnSend: false });
        let formData = new FormData();
        formData.append('Epost', values.Epost);
        formData.append('Fornavn', values.Fornavn);
        formData.append('Etternavn', values.Etternavn);
        formData.append('MainKategoriId', values.MainKategoriId);
        formData.append('SubKategoriId', values.SubKategoriId);
        formData.append('Spørsmål', values.Spørsmål);
        fetch("api/kundeservice/faqinn",
            {
                body: formData,
                method: "post"
            }).then(response => {
                if (response.ok) {
                    this.setState({
                        sendComplete: true
                    });
                } else {
                    this.setState({
                        errorMessage: "Kunne ikke sende inn spørsmålet ditt. Prøv igjen senere.", errorOnSend: true
                    });
                }
            });
    };
    onInvalidSubmit = (event, errors, values) => {
        this.setState({
            errorMessage: "Noe gikk galt! Sørg for at alle feltene er fylt inn riktig.", errorOnSend: true
        });
    };

    render() {
        return (
            <div>
                <Breadcrumb tag="nav" listTag="div">
                    <Link className="breadcrumb-item" to={'/'}>Hjem</Link>
                    <div className="active breadcrumb-item">Send spørsmål</div>
                </Breadcrumb>
                <h1>Gi oss din tilbakemelding</h1>
                <h4>Gi oss gjerne en tilbakemelding på din opplevelse hos oss, eller har du et spørsmål til oss? Vi svarer så raskt som mulig.</h4>
                <br></br><hr></hr>
                <AvForm hidden={this.state.sendComplete} ref={c => (this.formData = c)} onValidSubmit={this.onValidSubmit} onInvalidSubmit={this.onInvalidSubmit}>
                    <AvField name="Fornavn" label="Fornavn*" type="text" validate={{
                        required: { value: true, errorMessage: 'Skriv inn fornavnet ditt' },
                        pattern: { value: '^[a-zA-ZÆØÅæøå]+$', errorMessage: 'Fornavnet kan ikke inneholde tall eller spesialtegn' },
                        minLength: { value: 2, errorMessage: 'Fornavnet må være mellom 2 og 20 bokstaver' },
                        maxLength: { value: 20, errorMessage: 'Fornavnet må være mellom 2 og 20 bokstaver' }
                    }} />
                    <AvField name="Etternavn" label="Etternavn*" type="text" validate={{
                        required: { value: true, errorMessage: 'Skriv inn etternavnet ditt' },
                        pattern: { value: '^[a-zA-ZÆØÅæøå]+$', errorMessage: 'Etternavnet kan ikke inneholde tall eller spesialtegn' },
                        minLength: { value: 2, errorMessage: 'Etternavnet må være mellom 2 og 20 bokstaver' },
                        maxLength: { value: 20, errorMessage: 'Etternavnet må være mellom 2 og 20 bokstaver' }
                    }} />

                    {this.state.loadingMainKategorier && this.state.loadingSubKategorier
                        ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
                        : <div><AvField type="select" name="MainKategoriId" label="Velg en kategori" onChange={this.changeMainKategori.bind(this)} value={this.state.MainKategoriId}>
                            {this.state.MainKategorier.map(kategori =>
                                <option value={kategori.id} key={kategori.id}>{kategori.navn}</option>
                            )}
                        </AvField>
                            <AvField type="select" name="MainKategoriId" label="Velg en underkategori" onChange={this.changeSubKategori.bind(this)} value={this.state.SubKategoriId}>
                                {this.state.SubKategoriategorier.map(SubKategori =>
                                    <option value={SubKategori.id} key={SubKategori.id}>{SubKategori.navn}</option>
                                )}
                            </AvField>
                        </div>
                    }
                    <AvField name="Epost" label="Epost*" type="text" validate={{ email: true }} />
                    <AvField name="Spørsmål" label="Hva lurer du på?*" type="textarea" required />
                    {this.state.errorOnSend &&
                        <Alert color="danger">
                            {this.state.errorMessage}
                        </Alert>
                    }
                    <FormGroup>
                        <Button>Send Inn</Button>
                    </FormGroup>
                </AvForm>
                <Alert hidden={!this.state.sendComplete} color="success">
                    Takk for at du sendte inn spørsmålet ditt!
                </Alert>
            </div>
        );
    }

}

