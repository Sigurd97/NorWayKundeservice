import React, { Component } from 'react';
import StarRatingComponent from 'react-star-rating-component';
import { Collapse } from 'reactstrap';
import { IoIosArrowDown, IoIosArrowUp } from 'react-icons/io';

export class FAQCollapseItem extends Component {

    constructor(props) {
        super(props);
        this.toggleCollapse = this.toggleCollapse.bind(this);
        this.state = {
            collapse: false,
            rating: this.props.faq.rating,
            faq: this.props.faq
        };
    }

    toggleCollapse() {
        this.setState({ collapse: !this.state.collapse });
    }

    async onStarClick(nextValue, prevValue, name) {
        await fetch(`api/kundeservice/faqrating?faqId=${this.state.faq.id}&rating=${nextValue}`);
        this.setState({ rating: nextValue });
    }

    render() {
        let arrow = this.state.collapse ? <IoIosArrowUp className="arrow" /> : <IoIosArrowDown className="arrow" />;
        return (
            <div className="spmIndent">
                <h4 className="spm" onClick={this.toggleCollapse}>
                    {this.state.faq.spørsmål}{arrow}</h4>
                <hr></hr>

                <Collapse isOpen={this.state.collapse}>
                    <div dangerouslySetInnerHTML={{ __html: this.state.faq.svar }} />
                    <h2><StarRatingComponent
                        name="rating"
                        starCount={5}
                        value={this.state.rating}
                        onStarClick={this.onStarClick.bind(this)}
                    /></h2>
                </Collapse>
            </div>
        );
    }
}