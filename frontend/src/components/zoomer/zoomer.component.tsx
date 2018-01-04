import * as cn from 'classnames'

interface Props {
  imgSrcMin: string
  imgSrcFull: string
  alt?: string
}

@observer
export class Zoomer extends Component<Props, {}> {
  @observable isZoomed: boolean = false

  @action
  toggleZoom() {
    this.isZoomed = !this.isZoomed
  }

  render() {
    const { imgSrcMin, imgSrcFull, alt } = this.props

    return (
      <div className={cn('zoomer', { zoomer__opened: this.isZoomed })}>
        <img
          onClick={() => this.toggleZoom()}
          className="zoomer__img"
          src={imgSrcMin || imgSrcFull}
          alt={alt}
        />
        <div className="zoomer__popup">
          <img className="zoomer__popup_img" src={imgSrcFull} alt={alt} />
        </div>
      </div>
    )
  }
}
