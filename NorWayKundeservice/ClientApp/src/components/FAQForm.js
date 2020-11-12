import React from 'react';
import { Link } from 'react-router-dom';
import { AvForm, AvField } from 'availity-reactstrap-validation';
import { Button, FormGroup, Spinner, Breadcrumb, Alert } from 'reactstrap';

export class FAQForm extends React.Component {

    static displayName = FAQForm.name;

    constructor() {
        super();
        this.state = {
            hovedkategorier: [],
            underkategorier: [],
            loadingHovedkategorier: true,
            loadingUnderkategorier: true,
            hovedkategoriId: 1,
            underkategoriId: 1,
            errorOnSend: false,
            errorMessage: "",
            sendComplete: false
        };
    }

    componentDidMount() {
        this.populateHovedkategorier();
    }

    async changeHovedkategori(event) {
        this.setState({ hovedkategoriId: event.target.value });
        event.persist();

        await this.populateUnderkategorier(event.target.value);
    }

    async changeUnderkategori(event) {
        this.setState({ underkategoriId: event.target.value });
    }

    async populateHovedkategorier() {
        const response = await fetch('api/kundeservice/hovedkategorier');
        const data = await response.json();
        this.setState({ hovedkategorier: data, loadingHovedkategorier: false });
        await this.populateUnderkategorier(1);
    }

    async populateUnderkategorier(underkategoriId) {
        const response = await fetch('api/kundeservice/underkategorier?hovedkategoriId=' + underkategoriId);
        const data = await response.json();
        this.setState({ underkategoriId: underkategoriId, underkategorier: data, loadingUnderkategorier: false });
    }

    onValidSubmit = (event, values) => {
        this.setState({ errorOnSend: false });
        let formData = new FormData();
        formData.append('Epost', values.Epost);
        formData.append('Fornavn', values.Fornavn);
        formData.append('Etternavn', values.Etternavn);
        formData.append('HovedkategoriId', values.HovedkategoriId);
        formData.append('UnderkategoriId', values.UnderkategoriId);
        formData.append('Spørsmål', values.Spørsmål);
        fetch("api/kundeservice/faqinnsendt",
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
            errorMessage: "Noe gikk galt. Sørg for at alle feltene er fylt inn riktig.", errorOnSend: true
        });
    };

    render() {
        return (
            <div>
                <Breadcrumb tag="nav" listTag="div">
                    <Link className="breadcrumb-item" to={'/'}>Hjem</Link>
                    <div className="active breadcrumb-item">Send spørsmål</div>
                </Breadcrumb>
                <h1>Gi oss tilbakemelding</h1>
                <h4>Vil du gi oss ros eller ris, eller har du noen spørsmål til oss?</h4>
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

                    {this.state.loadingHovedkategorier && this.state.loadingUnderkategorier
                        ? <Spinner style={{ width: '3rem', height: '3rem' }} type="grow" />
                        : <div><AvField type="select" name="HovedkategoriId" label="Velg en kategori" onChange={this.changeHovedkategori.bind(this)} value={this.state.hovedkategoriId}>
                            {this.state.hovedkategorier.map(kategori =>
                                <option value={kategori.id} key={kategori.id}>{kategori.navn}</option>
                            )}
                        </AvField>
                            <AvField type="select" name="UnderkategoriId" label="Velg en underkategori" onChange={this.changeUnderkategori.bind(this)} value={this.state.underkategoriId}>
                                {this.state.underkategorier.map(underkategori =>
                                    <option value={underkategori.id} key={underkategori.id}>{underkategori.navn}</option>
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
                        <Button>Send skjema</Button>
                    </FormGroup>
                </AvForm>
                <Alert hidden={!this.state.sendComplete} color="success">
                    Takk for at du sendte inn spørsmålet ditt!
                </Alert>
            </div>
        );
    }

}

