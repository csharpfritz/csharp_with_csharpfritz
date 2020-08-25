FROM csharpfritz/fritznotebook:latest

# Set the environment variables
ARG NB_USER=jovyan
ARG NB_UID=1000
ENV USER ${NB_USER}
ENV NB_UID ${NB_UID}
ENV HOME /home/${NB_USER}

# Set root to notebooks
WORKDIR ${HOME}/notebooks/

# Copy notebooks
COPY ./notebooks/ ${HOME}/notebooks/
RUN chown -R ${NB_UID} ${HOME}
USER ${USER}