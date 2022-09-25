## Uncompress_Data.sh
#   - Shell script to prepare the tar/gzipped data folders for the tests
#
# Author: Peter Rokowski (prokow01@villanova.edu)

DATA_PATH="../Data/";
DATA_TAR="mnist_data.tgz";
#if [ -z "$DATA_TAR" ]; then
#    echo "bad param: DATA_TAR - not provided or null";
#    exit 1;
#fi


# make more complicated at some point
cd $DATA_PATH;
tar -xvf $DATA_TAR;
