import { useState } from 'react';
import { Container }  from './style'

import { BarChart1, BarChart2 } from '../../../Graphics/BarChart';
import PieChart from '../../../Graphics/PieChart';

import { dataTest, dataTestMesAnterior, dataTestMesAtual } from '../../../../Data/FakeData';

export default function Dashboard() {
    const [dataMesAtual, SetDataMesAtual] =  useState({
        datasets: [{
          data: dataTestMesAtual,
          backgroundColor: [
            "#E0DE2C", //Tempo perdido
            "#B13232", //Solicitações atrasadas
            "#2C953D", //Solicitações no prazo
            "#3532B1", //Manutenções 
          ],
        }],
      });

      const [dataMesAnterior, SetDataMesAnterior] =  useState({
        datasets: [{
          data: dataTestMesAnterior,
          backgroundColor: [
            "#E0DE2C", //Tempo perdido
            "#B13232", //Solicitações atrasadas
            "#2C953D", //Solicitações no prazo
            "#3532B1", //Manutenções 
          ],
        }],
      });


      const [dataPizza, SetDataPizza] = useState({
        //labels: ['Ativo', 'Em andamento', 'Finalizados'],
        datasets: [{
            label: 'Numero de solicitações por Status',
            data: [3, 5, 10],
            backgroundColor: [
                "#006400", //Finalizados
                "#4B0082", //Ativas
                "#FF8C00", //Em andamento
              ],
        }]
      })


    return (
        <>
            <Container>
                <div className='container-barra'>
                    <div className='graficos'>
                        <div  className='grafico-barra'>
                            <BarChart1  chartData={dataMesAtual} />
                        </div>
                       <div className='grafico-barra'>
                            <BarChart2  chartData={dataMesAnterior} />
                       </div>
                    </div>
                </div>
                <div className='container-infos'>
                    <div className='pizza'>
                        <h2 className='number-requests'>Número de solicitações por status</h2>
                        <div className='pizza-graphic'><PieChart className='pizza-graphic' chartData={dataPizza} />
                            <div className='legend'>
                                <div className='legend-item'>
                                    <div className='color-box' style={{ backgroundColor: '#4B0082' }}></div>
                                    <span>Ativas</span>
                                </div>
                            <div className='legend-item'>
                                <div className='color-box' style={{ backgroundColor: '#FF8C00' }}></div>
                                <span>Em andamento</span>
                            </div>
                                <div className='legend-item'>
                                <div className='color-box' style={{ backgroundColor: '#006400' }}></div>
                                <span>Finalizadas</span>
                            </div>
                        </div>
                    </div>
                </div>
                    <div className='info'>
                        <div className='sub-container-info'>
                            <div className='box'>
                                <div className='title'>
                                    <strong>Tempo perdido em manutenções</strong>
                                </div>
                                <div className='number'>10 h</div>
                            </div>
                            <div className='box'>
                                <div className='title'>
                                    <strong>Solicitações em atraso</strong>
                                </div>
                                <div className='number'>14</div>
                            </div>
                        </div> 
                        <div className='sub-container-info'>
                            <div className='box'>
                                <div className='title'>
                                    <strong>Solicitações atendidas no prazo</strong>
                                </div>
                                <div className='number'>22</div>
                            </div>
                            <div className='box'>
                                <div className='title'>
                                    <strong>Manutenções realizadas</strong>
                                </div>
                                <div className='number'>17</div>
                            </div>
                        </div>    
                    </div>
                </div>
            </Container>
        </>
    )
};