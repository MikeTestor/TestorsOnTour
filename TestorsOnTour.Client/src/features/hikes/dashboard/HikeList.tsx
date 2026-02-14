import { Box } from "@mui/material";
import HikeCard from "./HikeCard";

type Props={
    hikes: Hike[],
    onHikeSelect: (id: string) => void
}
export default function HikeList({hikes, onHikeSelect}: Props) {
  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 3 }}>
        {hikes.map(hike => 
            <HikeCard key={hike.id} hike={hike} onHikeSelect={onHikeSelect} />)}
    </Box>
  )
}