import { Grid} from "@mui/material";
import HikeList from "./HikeList";
import HikeDetail from "../details/HikeDetail";
import HikeForm from "../forms/HikeForm";

type Props={
	hikes: Hike[],
	selectedHike?: Hike,
	onHikeSelect: (id: string) => void,
	onHikeCancel: () => void
}
export default function HikesDashboard({ hikes, selectedHike, onHikeSelect, onHikeCancel }: Props) {
  return (
		<Grid container spacing={3}>
			<Grid size={7}>
				<HikeList hikes={hikes} 
						  onHikeSelect={onHikeSelect} />
			</Grid>
			<Grid size={5}>
				{selectedHike && <HikeDetail 
				 	hike={selectedHike} 
				 	onHikeCancel={onHikeCancel} /
				>}
				<HikeForm />
			</Grid>
		</Grid>
  )
}