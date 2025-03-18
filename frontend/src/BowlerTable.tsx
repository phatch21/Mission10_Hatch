// Payton Hatch
// Group 4-6
// Bowler table form

import { useEffect, useState } from "react";
import axios from "axios";

interface Bowler {
  bowlerId: number;
  fullName: string;
  teamName: string;
  address: string;
  city: string;
  state: string;
  zip: string;
  phone: string;
}

export default function BowlerTable() {
  const [bowlers, setBowlers] = useState<Bowler[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    console.log("Fetching API Data..."); // Debugging Log
    axios
      .get("https://localhost:7098/api/bowlers")
      .then((response) => {
        console.log("API Response:", response.data); // Debugging Log
        setBowlers(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching data:", error);
        setError("Failed to load bowlers");
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading bowlers...</p>;
  if (error) return <p style={{ color: "red" }}>{error}</p>;

  return (
    <div className="p-6">
      <h2 className="text-xl font-bold">Bowler List</h2>
      <table className="w-full border-collapse border border-gray-400">
        <thead>
          <tr className="bg-gray-200">
            <th className="border border-gray-400 px-4 py-2">Name</th>
            <th className="border border-gray-400 px-4 py-2">Team</th>
            <th className="border border-gray-400 px-4 py-2">Address</th>
            <th className="border border-gray-400 px-4 py-2">City</th>
            <th className="border border-gray-400 px-4 py-2">State</th>
            <th className="border border-gray-400 px-4 py-2">Zip</th>
            <th className="border border-gray-400 px-4 py-2">Phone</th>
          </tr>
        </thead>
        <tbody>
          {bowlers.map((bowler) => (
            <tr key={bowler.bowlerId}>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.fullName}
              </td>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.teamName}
              </td>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.address}
              </td>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.city}
              </td>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.state}
              </td>
              <td className="border border-gray-400 px-4 py-2">{bowler.zip}</td>
              <td className="border border-gray-400 px-4 py-2">
                {bowler.phone}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
