using MatrixTimesMatrix;
using System.Net;
using System.Security.AccessControl;

namespace SPL
{
    static public class Balistics
    {
        static public double[,] GetEndpoint(double[,] startPoint, double gravityForce, double mass, double energy, double angle, double time)
        {
            double[,] endPoint = new double[,] { { } };

            if (Validation(startPoint, endPoint, gravityForce, mass, energy, angle, time))
            {
                double speed = GetSpeed(energy, mass);


                return endPoint;
            }
            else
            {
                throw new Exception("there's something wrong in your values");
            }

        }
        static bool Validation(double[,] startPoint, double[,] endPoint, double gravityForce, double mass, double energy, double angle, double time)
        {
            if (MTM.CheckForPossibleAdditionOrSubstraction(endPoint, startPoint))
            {
                if (mass > 0)
                {
                    if (energy >= 0)
                    {
                        if (angle > 0)
                        {
                            if (time > 0)
                            {
                                return true;
                            }
                            else
                            {
                                throw new Exception("the time value is not valid (must be above 0)");
                            }
                        }
                        else
                        {
                            throw new Exception("the angle value is not valid (must be above 0 and bleow 360)");
                        }
                    }
                    else
                    {
                        throw new Exception("the energy value is not valid (must be above 0)");
                    }
                }
                else
                {
                    throw new Exception("the mass value is not valid (must be above 0)");
                }
            }
            else
            {
                throw new Exception("the startingPoint value is not valid ( use double[,]{ {X, Y} } )");
            }

        }
        static double GetSpeed(double energy, double mass)
        {
            // Ek = (m * v^2) : 2
            // 2 * Ek = m * v^2
            // (Ek * 2) : m = v^2
            // v = sqrt( (Ek * 2) : 2 )
            return (Math.Sqrt( (energy * 2 ) / mass ));
        }
    }
}